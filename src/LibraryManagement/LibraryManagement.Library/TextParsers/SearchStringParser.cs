namespace LibraryManagement.Library.TextParsers
{
    /// <summary>
    /// Search string parser.
    /// </summary>
    internal static class SearchStringParser
    {

        /// <summary>
        /// Parse search string and split into keywords.
        /// 
        /// Search string pattern: *val1* & *val2* & *val3*...
        /// </summary>
        /// <param name="searchString"></param>
        /// <returns></returns>
        internal static List<string> Parse(string searchString)
        {
            List<string> searchKeywords = new List<string>();

            // Search value separated by & if we have more than one.
            string[] keywords = searchString.Split("&", StringSplitOptions.RemoveEmptyEntries);

            foreach (string keyword in keywords)
            {
                var keywordTrimmed = keyword.Trim();
                // Take value between stars *..*
                searchKeywords.Add(keywordTrimmed.Substring(1, keywordTrimmed.Length - 2).Trim());
            }

            return searchKeywords;
        }
    }
}
