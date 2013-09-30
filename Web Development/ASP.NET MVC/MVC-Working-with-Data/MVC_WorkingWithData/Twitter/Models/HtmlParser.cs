using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Twitter.Models
{
    public static class HtmlParser
    {
        public static string ActionLink(this string s, string url)
        {
            return string.Format("<a href=\"{0}\" data-ajax='true' data-ajax-method='GET' " +
            "data-ajax-mode='replace' data-ajax-update='#tweets' target=\"_blank\">{1}</a>", url, s);
        }

        public static string Link(this string s, string url)
        {
            return string.Format("<a href=\"{0}\" target=\"_blank\">{1}</a>", url, s);
        }

        public static string ParseURL(this string s)
        {
            return Regex.Replace(s, @"(http(s)?://)?([\w-]+\.)+[\w-]+(/\S\w[\w- ;,./?%&=]\S*)?", new MatchEvaluator(HtmlParser.URL));
        }

        //public static string ParseUsername(this string s)
        //{
        //    return Regex.Replace(s, "(@)((?:[A-Za-z0-9-_]*))", new MatchEvaluator(HtmlParser.Username));
        //}

        public static string ParseHashtag(this string s)
        {
            return Regex.Replace(s, "(#)((?:[A-Za-z0-9-_]*))", new MatchEvaluator(HtmlParser.Hashtag));
        }

        public static List<string> GetHashtag(this string s)
        {
            var matchList = Regex.Matches(s, "(#)((?:[A-Za-z0-9-_]*))", RegexOptions.IgnoreCase);
            var tagsList = matchList.Cast<Match>().Select(match => match.Value).ToList();
            return tagsList;
        }

        private static string Hashtag(Match m)
        {
            string x = m.ToString();
            string tag = x.Replace("#", "%23");
            return x.ActionLink("/Twitter/Search?tag=" + x.Substring(1));
        }

        //private static string Username(Match m)
        //{
        //    string x = m.ToString();
        //    string username = x.Replace("@", "");
        //    return x.Link("http://twitter.com/" + username);
        //}

        private static string URL(Match m)
        {
            string x = m.ToString();
            return x.Link(x);
        }
    }
}