using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using WikipediaDataRequests.Core;
using WikipediaDataRequests.Core.Wiki;

namespace WikipediaDataRequests
{
    public class WikiSearchController
    {
        private readonly IWikiSearch _wikipedia;
        private readonly BackgroundWorker _worker;


        public List<CompareInfo> CompareInfo { get; }

        public WikiSearchController(IWikiSearch wikipedia)
        {
            _wikipedia = wikipedia;
            CompareInfo = new List<CompareInfo>();
            _worker = new BackgroundWorker();
            _worker.DoWork += WorkerOnDoWork ;

        }

        private void WorkerOnDoWork(object sender, DoWorkEventArgs doWorkEventArgs)
        {
            var args = (Tuple<decimal, decimal, int>)doWorkEventArgs.Argument;
            var res = GetAllImagesNamesOnPoint(args.Item1, args.Item2, args.Item3);
            CompareInfo.Clear();
            CompareInfo.AddRange(res);

            NeedToUpdate?.Invoke(this, null);
        }

        public event EventHandler NeedToUpdate;

        public List<Geosearch> GetGeoData(decimal x, decimal y, int limit)
        {
            _wikipedia.List = ListType.Geosearch;
            _wikipedia.Format = Format.Json;
            _wikipedia.Limit = limit;
            _wikipedia.ExternParameters.Add(new Tuple<string, object>("gsradius", 10000));
            _wikipedia.ExternParameters.Add(new Tuple<string, object>("gscoord", string.Join("|", new[] {x, y})));
            var responce = _wikipedia.Search<GeoRootObject>(null);
            return responce?.Query?.GeoSearch;
        }

        public ImageCollection GetImageData(int pageid)
        {
            _wikipedia.List = ListType.Unknown;
            _wikipedia.Format = Format.Json;
            _wikipedia.ExternParameters.Add(new Tuple<string, object>("prop", "images"));
            _wikipedia.ExternParameters.Add(new Tuple<string, object>("pageids", pageid));
            var responce = _wikipedia.Search<ImagesRootObject>(null);
            return responce?.Query?.Pages?.FirstOrDefault().Value;
        }

        public List<CompareInfo> GetAllImagesNamesOnPoint(decimal x, decimal y, int limit)
        {
            var list = (from geosearch in GetGeoData(x, y, limit) from image in GetImageData(geosearch.PageId).Images
                        select new Tuple<int, string>(geosearch.PageId, image.Title.Replace("File:", ""))).ToList();

            return Compare(list).Select(tuple => new CompareInfo() {CompareIndex = tuple.Item1, TitleImage1 = tuple.Item2, TitleImage2 = tuple.Item3}).ToList();
        }

        public void GetAllImagesNamesOnPointAsync(decimal x, decimal y, int limit)
        {
            _worker.RunWorkerAsync(new Tuple<decimal, decimal, int>(x, y, limit));
        }

        private static IEnumerable<Tuple<double, string, string>> Compare( List<Tuple<int, string>> wikiImages)
        {
            for (var i = 0; i < wikiImages.Count; i++)
            {
                for (var j = i + 1; j < wikiImages.Count; j++)
                {
                    var res = Shingle.CulculateSimple(wikiImages[i].Item2, wikiImages[j].Item2);
                    if (res > 0 && res < 1)
                        yield return new Tuple<double, string, string>(res, wikiImages[i].Item2, wikiImages[j].Item2);
                }
            }
        }
    }

    public class CompareInfo
    {
        public string TitleImage1 { get; set; }

        public string TitleImage2 { get; set; }

        public double CompareIndex { get; set; }
    }
}
