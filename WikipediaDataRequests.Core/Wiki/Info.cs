namespace WikipediaDataRequests.Core.Wiki
{
    public enum Info
    {
        /// <summary>
        /// The number of search results
        /// </summary>
        TotalHits,

        /// <summary>
        /// A suggestion that might fit better than what you searched for.
        /// </summary>
        Suggestion
    }

    public enum ListType
    {
        Unknown,
        Search,
        Geosearch
    }
}