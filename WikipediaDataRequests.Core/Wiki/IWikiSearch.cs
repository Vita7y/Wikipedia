using System;
using System.Collections.Generic;

namespace WikipediaDataRequests.Core.Wiki
{
    public interface IWikiSearch
    {
        bool UseTls { get; set; }

        Format Format { get; set; }

        List<Info> Infos { get; set; }

        int Limit { get; set; }

        int Offset { get; set; }

        List<int> Namespaces { get; set; }

        List<Property> Properties { get; set; }

        bool Redirects { get; set; }

        What What { get; set; }

        bool ServedBy { get; set; }

        string RequestId { get; set; }

        ListType List { get; set; }

        List<Tuple<string, object>> ExternParameters { get; set; }

        T Search<T>(string query);
    }
}
