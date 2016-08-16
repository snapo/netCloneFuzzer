using Fiddler;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCloneFuzzer
{
    public class FiddlerEngine
    {
        private const int NORMAL_PORT = 8877;
        private const int SSL_PORT = 8888;
        private const string SSL_HOST = "localhost";

        private static Proxy _SecureEndpoint;
        private static FiddlerCoreStartupFlags startupOptions = FiddlerCoreStartupFlags.Default;
        private static RemoteCertificateValidationCallback remoteCertValidationCB;

        private static bool _certificatesValid = false;

        public static string HostFilter { get; set; }
        public static int Multiplicator { get; set; }
        public static ReplacementEngine Replacer { get; set; }
        public static AddLogMessageDelegate Logger { get; set; }

        static FiddlerEngine()
        {
            FiddlerApplication.SetAppDisplayName("NetCloneFuzzer");

            FiddlerApplication.OnNotification += HandleOnNotification;
            FiddlerApplication.Log.OnLogString += HandleOnLogString;

            FiddlerApplication.AfterSessionComplete += HandleAfterSessionComplete;

            CONFIG.IgnoreServerCertErrors = true;

            //FiddlerCore will immediately dump streaming response data
            FiddlerApplication.Prefs.SetBoolPref("fiddler.network.streaming.ForgetStreamedData", true);
            FiddlerApplication.Prefs.SetBoolPref("fiddler.certmaker.PreferCertEnroll", false);

            //startupOptions &= ~FiddlerCoreStartupFlags.AllowRemoteClients;
        }

        private static void HandleOnLogString(object sender, LogEventArgs e)
        {
            Log(LogMessageType.Information, "FiddlerLog: " + e.LogString);
        }

        private static void HandleOnNotification(object sender, NotificationEventArgs e)
        {
            Log(LogMessageType.Information, "FiddlerNotify: " + e.NotifyString);
        }

        public static bool ValidateCertificates()
        {
            if (!CertMaker.rootCertExists())
            {
                Log(LogMessageType.Error, "Root certificate does not exist");
                _certificatesValid = false;
                return false;
                //Log(LogMessageType.Information, "Root certificate does not exist -> Creating");
                //if (!CertMaker.createRootCert())
                //{
                //    Log(LogMessageType.Error, "Creation of root certificate failed.");
                //    _certificatesValid = false;
                //    return false;
                //}
            }

            if (!CertMaker.rootCertIsTrusted() && !CertMaker.rootCertIsMachineTrusted())
            {
                Log(LogMessageType.Error, "Root certificate is not trusted");
                _certificatesValid = false;
                return false;
                //Log(LogMessageType.Information, "Root certificate is not trusted -> Trusting");
                //if (!CertMaker.trustRootCert())
                //{
                //    Log(LogMessageType.Error, "Trusting root certificate failed.");
                //    _certificatesValid = false;
                //    return false;
                //}
            }
            _certificatesValid = true;
            return true;
        }

        public static bool RemoveCertificates()
        {
            //Log(LogMessageType.Information, "Removing certificates");
            //if (!CertMaker.removeFiddlerGeneratedCerts(true))
            //{
            //    Log(LogMessageType.Error, "Generated certificates could not be removed");
            //    return false;
            //}
            //_certificatesValid = false;
            return true;
        }

        public static bool Startup()
        {
            if (!_certificatesValid) {
                Log(LogMessageType.Error, "could not start. certificates not ready");
                return false;
            }

            Log(LogMessageType.Information, "Starting with settings: [{0}]", startupOptions);
            FiddlerApplication.Startup(NORMAL_PORT, startupOptions);
            _SecureEndpoint = FiddlerApplication.CreateProxyEndpoint(SSL_PORT, true, SSL_HOST);
            if (_SecureEndpoint == null)
            {
                Shutdown();
                Log(LogMessageType.Error, "Secure Endpoint could not be created");
                return false;
            }

            return true;
        }

        public static void Shutdown()
        {
            if (_SecureEndpoint != null)
            {
                _SecureEndpoint.Dispose();
                _SecureEndpoint = null;
            }

            if (FiddlerApplication.IsStarted())
            {
                FiddlerApplication.Shutdown();
            }
        }

        private static bool FitsMask(string FileName, string FileMask)
        {
            if (string.IsNullOrEmpty(FileMask)) { return true; }
            Regex mask = new Regex(
                '^' +
                FileMask
                    .Replace(".", "[.]")
                    .Replace("*", ".*")
                    .Replace("?", ".")
                + '$',
                RegexOptions.IgnoreCase);
            return mask.IsMatch(FileName);
        }

        private static void Log(LogMessageType type, string messageFormat, params object[] args)
        {
            Log(type, string.Format(messageFormat, args));
        }
        private static void Log(LogMessageType type, string message)
        {
            System.Diagnostics.Trace.WriteLine(string.Format("{0}: {1}", type, message));
            if (Logger == null) { return; }
            Logger(type, message);
        }

        private static void HandleAfterSessionComplete(Session session)
        {
            if (!session.HTTPMethodIs("POST")) { return; }
            if (!FitsMask(session.oRequest.host, HostFilter)) { return; }
            if (Replacer == null) { return; }

            Log(LogMessageType.Information, "Processing request to URL: '{0}'", session.fullUrl);

            string sHeader = "";

            foreach (var item in session.oRequest.headers)
            {
                sHeader += string.Format("{0}: {1}\n", item.Name, item.Value);
            }
            sHeader = sHeader.TrimEnd();

            Encoding bodyEnc = session.GetRequestBodyEncoding();
            string sBody = session.GetRequestBodyAsString();

            RequestPostData baseData = new RequestPostData(session.fullUrl, sHeader, sBody, bodyEnc);

            List<RequestPostData> requests = new List<RequestPostData>(Multiplicator);
            for (int i = 0; i < Multiplicator; i++)
            {
                RequestPostData newData = new RequestPostData(baseData);
                Replacer.ReplaceHeader(newData);
                Replacer.ReplaceBody(newData);
                newData.UpdateRequest();
                requests.Add(newData);
                baseData = newData;
            }

            ServicePointManager.ServerCertificateValidationCallback = null;

            Parallel.ForEach<RequestPostData>(requests, req =>
            {
#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
                SendRequest(req);
#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            });

            //                foreach (RequestPostData data in _requests)
            //                {
            //#pragma warning disable CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            //                    SendRequest(data);
            //#pragma warning restore CS4014 // Because this call is not awaited, execution of the current method continues before the call is completed
            //                }
        }

        private static async Task SendRequest(RequestPostData request)
        {
            using (HttpClient client = new HttpClient(new HttpClientHandler() { UseProxy = false, CookieContainer = request.Cookies }))
            {
                try
                {
                    await client.SendAsync(request.HttpMessage);
                }
                catch (Exception ex)
                {
                    Log(LogMessageType.Error, "Request could not be send: {0}", ex.GetFullMessage());
                }
            }
        }
    }
}
