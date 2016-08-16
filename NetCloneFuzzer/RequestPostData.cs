using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace NetCloneFuzzer
{
    public class RequestPostData
    {
        public Uri Uri { get; set; }
        public Dictionary<string, string> Header { get; set; }
        public Dictionary<string, string> NonSettableHeader { get; set; }
        public string Body { get; set; }
        public Encoding BodyEncoding { get; set; }
        public HttpRequestMessage HttpMessage { get; set; }
        public CookieContainer Cookies { get; set; }

        public RequestPostData(string url, string header, string body, Encoding bodyEncoding)
        {
            this.Uri = new Uri(url);
            this.Header = new Dictionary<string, string>();
            this.NonSettableHeader = new Dictionary<string, string>();
            this.Body = body;
            this.BodyEncoding = bodyEncoding;
            this.HttpMessage = new HttpRequestMessage(HttpMethod.Post, url);
            this.Cookies = new CookieContainer();

            foreach (Match headerEntry in Regex.Matches(header, "([^:]+): (.+)"))
            {
                string name = headerEntry.Groups[1].Value.TrimStart();
                string value = headerEntry.Groups[2].Value;

                if (name.Equals("content-length", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (name.Equals("content-type", StringComparison.InvariantCultureIgnoreCase)) { continue; }
                if (name.Equals("cookie", StringComparison.InvariantCultureIgnoreCase))
                {
                    string[] cookieKeyValueGroups = value.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);
                    foreach (string cookieKeyValue in cookieKeyValueGroups)
                    {
                        string[] keyValue = cookieKeyValue.Split(new char[] { '=' }, 2);
                        if (keyValue.Length == 2)
                        {
                            string cookieName = keyValue[0].Trim();
                            string cookieValue = keyValue[1].Trim();

                            try {
                                this.Cookies.Add(this.Uri, new Cookie(cookieName, cookieValue));
                            }
                            catch (CookieException)
                            {
                                int iCommaPos = cookieValue.IndexOf(",");
                                if (iCommaPos > 0)
                                {
                                    cookieValue = cookieValue.Substring(0, iCommaPos);
                                }
                                this.Cookies.Add(this.Uri, new Cookie(cookieName, cookieValue));
                            }
                        }
                    }
                    continue;
                }

                if (!this.HttpMessage.Headers.TryAddWithoutValidation(name, value))
                {
                    this.NonSettableHeader.Add(name, value);
                }
                else
                {
                    this.Header.Add(name, value);
                }
            }

            this.HttpMessage.Content = new StringContent(body, BodyEncoding);
        }

        public RequestPostData(RequestPostData data)
        {
            this.Uri = data.Uri;
            this.Header = new Dictionary<string, string>(data.Header.Count);
            foreach (KeyValuePair<string, string> headerEntry in data.Header)
            {
                this.Header.Add(headerEntry.Key, headerEntry.Value);
            }

            this.NonSettableHeader = new Dictionary<string, string>(); //Not of interest anymore - Also reduces Log output procudes from FiddlerEngine
            this.Body = data.Body;
            this.BodyEncoding = data.BodyEncoding;
            this.HttpMessage = new HttpRequestMessage(HttpMethod.Post, data.Uri);

            this.Cookies = new CookieContainer(data.Cookies.Count);
            foreach (Cookie cookie in data.Cookies.GetCookies(this.Uri))
            {
                this.Cookies.Add(data.Uri, new Cookie(cookie.Name, cookie.Value));
            }
        }

        public void UpdateRequest()
        {
            this.HttpMessage.Content = new StringContent(this.Body, this.BodyEncoding);

            foreach (KeyValuePair<string, string> kvp in this.Header)
            {
                this.HttpMessage.Headers.TryAddWithoutValidation(kvp.Key, kvp.Value);
            }
        }
    }
}
