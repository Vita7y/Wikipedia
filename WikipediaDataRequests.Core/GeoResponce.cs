using System.Collections.Generic;

namespace WikipediaDataRequests.Core
{
    public class Geosearch
    {
        public int PageId { get; set; }

        public int NS { get; set; }

        public string Title { get; set; }

        public double Lat { get; set; }

        public double Lon { get; set; }

        public double Dist { get; set; }

        public string Primary { get; set; }
    }

    public class Query
    {
        public List<Geosearch> GeoSearch { get; set; }
    }

    public class GeoRootObject
    {
        public string BatchComplete { get; set; }

        public Query Query { get; set; }
    }
}
