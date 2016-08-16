using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace NetCloneFuzzer
{
    public class ReplacementEngine
    {
        public FilterContainer FilterContainer { get; private set; }

        public ReplacementEngine()
        {
            this.FilterContainer = new FilterContainer();
        }

        public void ReplaceBody(RequestPostData data)
        {
            if (!this.FilterContainer.HasFilters) { return; }

            string value = data.Body;
            int iIndexOffset = 0;
            foreach (var filter in this.FilterContainer.Filters)
            {
                if (filter.Type != FilterType.Body && filter.Type != FilterType.HeaderAndBody) { continue; }
                Match m = Regex.Match(value, filter.Regex);
                if (!m.Success) { continue; }
                this.ApplyManipulations(m, ref value, ref iIndexOffset, filter.Manipulations);
            }
            data.Body = value;
        }

        public void ReplaceHeader(RequestPostData data)
        {
            if (!this.FilterContainer.HasFilters) { return; }

            int iIndexOffset = 0;
            Dictionary<string, string> newHeaders = new Dictionary<string, string>(data.Header.Count);
            foreach (KeyValuePair<string, string> headerEntry in data.Header)
            {
                string value = string.Format("{0}: {1}", headerEntry.Key, headerEntry.Value);

                foreach (var filter in this.FilterContainer.Filters)
                {
                    if (filter.Type != FilterType.Header && filter.Type != FilterType.HeaderAndBody) { continue; }
                    Match m = Regex.Match(value, filter.Regex);
                    if (!m.Success) { continue; }
                    this.ApplyManipulations(m, ref value, ref iIndexOffset, filter.Manipulations);
                }

                string[] newHeaderValues = value.Split(new char[] { ':' }, 2);
                if (newHeaderValues.Length == 2)
                {
                    newHeaders.Add(newHeaderValues[0].Trim(), newHeaderValues[1].Trim());
                }
                else
                {
                    newHeaders.Add(headerEntry.Key, headerEntry.Value);
                }
            }
            data.Header.Clear();
            data.Header = newHeaders;

            iIndexOffset = 0;
            foreach (Cookie cookie in data.Cookies.GetCookies(data.Uri))
            {
                string value = string.Format("{0}={1}", cookie.Name, cookie.Value);

                foreach (var filter in this.FilterContainer.Filters)
                {
                    if (filter.Type != FilterType.Header && filter.Type != FilterType.HeaderAndBody) { continue; }
                    Match m = Regex.Match(value, filter.Regex);
                    if (!m.Success) { continue; }
                    this.ApplyManipulations(m, ref value, ref iIndexOffset, filter.Manipulations);
                }

                string[] newCookieValues = value.Split(new char[] { '=' }, 2);
                if (newCookieValues.Length == 2)
                {
                    cookie.Name = newCookieValues[0];
                    cookie.Value = newCookieValues[1];
                }
            }
        }

        private void ApplyManipulations(Match m, ref string value, ref int indexOffset, IList<FilterMatchGroupManipulation> manipulations)
        {
            foreach (var manipulation in manipulations)
            {
                Group g = null;
                int iGroupIndex = 0;
                if (int.TryParse(manipulation.GroupName, out iGroupIndex))
                {
                    g = m.Groups[iGroupIndex];
                }
                else
                {
                    g = m.Groups[manipulation.GroupName];
                }

                if (g == null) { continue; }

                string sReplacement = manipulation.GetReplacementValue(g.Value);
                int iLengthBefore = g.Length;
                int iLengthAfter = sReplacement.Length;

                value = value.Remove(g.Index + indexOffset, iLengthBefore);
                value = value.Insert(g.Index + indexOffset, sReplacement);

                indexOffset += iLengthAfter - iLengthBefore;
            }
        }
    }
}
