using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WikipediaDataRequests.Core;
using WikipediaDataRequests.Core.Wiki;

namespace WikipediaDataRequests.Test
{
    [TestClass]
    public class UnitTest_Responce
    {
        [TestMethod]
        public void TestMethod_GetGeoItems()
        {
            var wiki = new Wikipedia
            {
                List = ListType.Geosearch,
                Format = Format.Json,
                Limit = 50
            };
            wiki.ExternParameters.AddRange(new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("gsradius", 10000),
                    new Tuple<string, object>("gscoord", string.Join("|", new[] {37.786971,-122.399677}))
                });

            var responce = wiki.Search<GeoRootObject>(null);

            Assert.IsNotNull(responce);
            Assert.AreEqual(50, responce.Query.GeoSearch.Count);
        }

        [TestMethod]
        public void TestMethod_GetImages()
        {
            var wiki = new Wikipedia
            {
                Format = Format.Json
            };
            wiki.ExternParameters.AddRange(new List<Tuple<string, object>>()
            {
                new Tuple<string, object>("prop", "images"),
                new Tuple<string, object>("pageids", 18618509)
            });

            var responce = wiki.Search<ImagesRootObject>(null);
                

            Assert.IsNotNull(responce);
            Assert.IsTrue(responce.Query.Pages.Values.First().Images.Count > 0);
        }

        [TestMethod]
        public void TestMethod_GetAllFilesNames()
        {
            var wiki = new Wikipedia
            {
                List = ListType.Geosearch,
                Format = Format.Json,
                Limit = 50
            };
            wiki.ExternParameters.AddRange(new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("gsradius", 10000),
                    new Tuple<string, object>("gscoord", string.Join("|", new[] {37.786971,-122.399677}))
                });

            var responce = wiki.Search<GeoRootObject>(null);

            TextWriter fileRaw = File.CreateText(DateTime.Now.ToString("yyMMddhhss") + "Raw.txt");
            TextWriter file = File.CreateText(DateTime.Now.ToString("yyMMddhhss") + ".txt");
            List<Tuple<int,string>> wikiImages = new List<Tuple<int,string>>();

            foreach (Geosearch geosearch in responce.Query.GeoSearch)
            {
                var wikiFile = new Wikipedia{Format = Format.Json};
                wikiFile.ExternParameters.AddRange(new List<Tuple<string, object>>()
                {
                    new Tuple<string, object>("prop", "images"),
                    new Tuple<string, object>("pageids", geosearch.PageId)
                });

                var responceFile = wikiFile.Search<ImagesRootObject>(null);
                wikiImages.AddRange(from images in responceFile.Query.Pages.Values from image in images.Images select new Tuple<int, string>(geosearch.PageId, image.Title.Replace("File:","")));
            }

            foreach (var t in wikiImages)
            {
                fileRaw.WriteLine($"{t.Item1}; {t.Item2}");
            }
            for (int i = 0; i < wikiImages.Count; i++)
            {
                for (int j = i+1; j < wikiImages.Count; j++)
                {
                    var res = Shingle.CulculateSimple(wikiImages[i].Item2, wikiImages[j].Item2);
                    if (res > 0 && res < 1)
                        file.WriteLine($"{wikiImages[i].Item1}; {wikiImages[j].Item1}; {(int)(res*10000)}; {wikiImages[i].Item2}; {wikiImages[j].Item2};");
                }
            }
        }

        [TestMethod]
        public void TestMethod_Shingle()
        {
            var str = "Location map San Francisco Central.png";
            var res = Shingle.CulculateSimple(str, str);
            Assert.AreEqual((double)1, res);
        }

    }
}
