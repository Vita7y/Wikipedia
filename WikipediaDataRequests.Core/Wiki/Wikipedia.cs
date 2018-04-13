using System;
using System.Collections.Generic;
using RestSharp;
using RestSharp.Deserializers;

namespace WikipediaDataRequests.Core.Wiki
{
    public class Wikipedia: IWikiSearch
    {
        private static readonly RestClient Client = new RestClient();

        public Wikipedia()
        {
            Format = Format.Xml;

            Infos = new List<Info>();
            Namespaces = new List<int>();
            Properties = new List<Property>();
            ExternParameters = new List<Tuple<string, object>>();
        }

        /// <summary>
        /// Set to true to use HTTPS instead of HTTP.
        /// </summary>
        public bool UseTls { get; set; }

        /// <summary>
        /// Gets or sets the format to use.
        /// Note: This currently defaults only to XML - once RestSharp gets DeserializeAs attributes for JSON, I will implement support for JSON as well.
        /// </summary>
        public Format Format { get; set; }

        /// <summary>
        /// What metadata to return.
        /// Default: TotalHits, Suggestion
        /// </summary>
        public List<Info> Infos { get; set; }

        /// <summary>
        /// How many total pages to return.
        /// Default: 10
        /// Max: 50
        /// </summary>
        public int Limit { get; set; }

        /// <summary>
        /// Use this value to continue paging (return by query).
        /// Default: 0
        /// </summary>
        public int Offset { get; set; }

        /// <summary>
        /// The namespace(s) to enumerate.
        /// When the list is empty, it implicitly contains 0, the default namespace to search.
        /// </summary>
        public List<int> Namespaces { get; set; }

        /// <summary>
        /// What propery to include in the results.
        /// Defaults to a combination of snippet, size, wordcount and timestamp
        /// </summary>
        public List<Property> Properties { get; set; }

        /// <summary>
        /// Include redirect pages in the search.
        /// </summary>
        public bool Redirects { get; set; }

        /// <summary>
        /// Gets or sets the place to search.
        /// </summary>
        public What What { get; set; }

        /// <summary>
        /// Include the hostname that served the request in the results. Unconditionally shown on error.
        /// </summary>
        public bool ServedBy { get; set; }

        /// <summary>
        /// Request ID to distinguish requests. This will just be output back to you.
        /// </summary>
        public string RequestId { get; set; }

        public ListType List { get; set; }

        public List<Tuple<string, object>> ExternParameters { get; set; }

        public T Search<T>(string query)
        {
            //API example: http://en.wikipedia.org/w/api.php?action=query&list=search&srsearch=wikipedia&srprop=timestamp
            Client.BaseUrl = new Uri(string.Format((UseTls ? "https://{0}.wikipedia.org/w/" : "http://{0}.wikipedia.org/w/"), "en"));

            RestRequest request = new RestRequest("api.php", Method.GET);

            //Required
            request.AddParameter("action", "query");
            request.AddParameter("format", Format.ToString().ToLower());

            if (ExternParameters != null)
            {
                foreach (var parameter in ExternParameters)
                {
                    if (!string.IsNullOrWhiteSpace(parameter.Item1) && parameter.Item2 != null)
                        request.AddParameter(parameter.Item1, parameter.Item2);
                }
            }

            if (!string.IsNullOrWhiteSpace(query))
                request.AddParameter("srsearch", query);

            //Optional
            if (Infos.HasElements())
                request.AddParameter("srinfo", string.Join("|", Infos).ToLower());

            if (Limit != 0)
            {
                switch (List)
                {
                        case ListType.Geosearch:
                        request.AddParameter("list", List.ToString().ToLower());
                        request.AddParameter("gslimit", Limit);
                        break;
                        case ListType.Search:
                        request.AddParameter("list", List.ToString().ToLower());
                        request.AddParameter("srlimit", Limit);
                        break;
                }
            }

            if (Offset != 0)
                request.AddParameter("sroffset", Offset);

            if (Namespaces.HasElements())
                request.AddParameter("srnamespace", string.Join("|", Namespaces).ToLower());

            if (Properties.HasElements())
                request.AddParameter("srprop", string.Join("|", Properties).ToLower());

            if (Redirects)
                request.AddParameter("srredirects", Redirects.ToString().ToLower());

            if (What != What.Title)
                request.AddParameter("srwhat", What.ToString().ToLower());

            if (ServedBy)
                request.AddParameter("servedby", ServedBy.ToString().ToLower());

            if (!string.IsNullOrEmpty(RequestId))
                request.AddParameter("requestid", RequestId);

            //Output
            RestResponse response = (RestResponse)Client.Execute(request);

            IDeserializer deserializer;

            switch (Format)
            {
                case Format.Xml:
                    deserializer = new XmlAttributeDeserializer();
                    break;
                case Format.Json:
                    deserializer = new JsonDeserializer();
                    break;
                default:
                    deserializer = new XmlAttributeDeserializer();
                    break;
            }

            //The format that Wikipedia uses
            deserializer.DateFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss'Z'";

           return deserializer.Deserialize<T>(response);
        }
    }
}