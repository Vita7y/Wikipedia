using System.Collections.Generic;

namespace WikipediaDataRequests.Core
{
    public class Continue
    {
        public string ImContinue { get; set; }
    }

    public class Image
    {
        public int NS { get; set; }

        public string Title { get; set; }
    }

    public class ImageCollection
    {
        public int PageId { get; set; }

        public int NS { get; set; }

        public string Title { get; set; }

        public List<Image> Images { get; set; }
    }

    public class ImageQuery
    {
        public Dictionary<string, ImageCollection> Pages { get; set; }
    }

    public class ImagesRootObject
    {
        public Continue Continue { get; set; }

        public ImageQuery Query { get; set; }
    }
}
