using System;
using System.Collections.Generic;
using System.Linq;

namespace WikipediaDataRequests.Core
{
    public class Shingle
    {
        private const int NumHash = 84;
        private const int StartHash = 10;
        //private const int ShingleLen = 3;
        private static readonly List<string> Separators = new List<string>{ ".",",",";",":","!","?", "-" };

        public static double CulculateSimple(string str1, string str2)
        {
            if (string.IsNullOrWhiteSpace(str1) || string.IsNullOrWhiteSpace(str2))
                return 0;
            if (str1 == str2)
                return 1;

            var temp1 = str1;
            temp1 = temp1.ToLower();
            temp1 = Separators.Aggregate(temp1, (current, separator) => current.Replace(separator, " "));

            var temp2 = str2;
            temp2 = temp2.ToLower();
            temp2 = Separators.Aggregate(temp2, (current, separator) => current.Replace(separator, ""));

            var words1 = SplitWords(temp1);
            var words2 = SplitWords(temp2);

            var shingLen = words1.Count > words2.Count ? words2.Count : words1.Count;

            var shingles1 = CreateShingles(words1, shingLen);
            var hashes1 = GetHashes(shingles1, StartHash);

            var shingles2 = CreateShingles(words2, shingLen);
            var hashes2 = GetHashes(shingles2, StartHash);


            var min1 = GetHashMinimums(hashes1);
            var min2 = GetHashMinimums(hashes2);
            return CompareHashes(min1, min2);
        }

        private static List<string> SplitWords(string text)
        {
            var result = new List<string>(text.Split(' '));
            return result;
        }

        private static IEnumerable<string> CreateShingles(IReadOnlyList<string> words, int shingleLen)
        {
            var result = new List<string>();
            for (var i = 0; i < words.Count - shingleLen + 1; i++)
            {
                result.Add("");
                for (var j = i; j < i + shingleLen; j++)
                    result[i] += words[j] + " ";
                var trim = result[i].Trim();
                result[i] = trim;
            }

            return result;
        }

        private static long PolinomialHash(int p, string str)
        {
            long res = 0;
            long ppow = 1;

            foreach (var t in str)
            {
                res += t * ppow;
                ppow *= p;
            }
            return res;
        }

        private static List<List<long>> GetHashes(IEnumerable<string> shingles, int startHash)
        {
            var result = new List<List<long>>();

            foreach (var shingle in shingles)
            {
                var tmp = new List<long>();
                for (var i = startHash; i < startHash + NumHash; i++)
                    tmp.Add(Math.Abs(PolinomialHash(i, shingle)));
                result.Add(tmp);
            }

            return result;
        }

        private static List<long> GetHashMinimums(IReadOnlyList<List<long>> inc)
        {
            var min = inc[0];

            for (var i = 1; i < inc.Count; i++)
            for (var j = 0; j < NumHash; j++)
                if (inc[i][j] < min[j])
                    min[j] = inc[i][j];

            return min;
        }

        private static double CompareHashes(IReadOnlyCollection<long> orig, IReadOnlyList<long> suspect)
        {
            var acc = orig.Where((t, i) => t == suspect[i]).Count();
            var result = acc / (double) orig.Count;
            return result;
        }

        private static int CompareLists(IReadOnlyList<long> l1, IReadOnlyList<long> l2)
        {
            return l1.Where((t, i) => t != l2[i]).Any() ? 0 : 1;
        }

        private static List<List<long>> GetSuperShingles(IReadOnlyList<long> mins)
        {
            var res = new List<List<long>>();

            for (var i = 0; i < mins.Count; i++)
            {
                if (i % 6 == 0)
                {
                    var tmp = new List<long>();
                    res.Add(tmp);
                }
                res[i / 6].Add(mins[i]);
            }
            return res;
        }

        private static double CompareSuperShingles(IReadOnlyCollection<List<long>> inc1, IReadOnlyList<List<long>> inc2)
        {
            var acc = inc1.Where((t, i) => CompareLists(t, inc2[i]) == 1).Count();
            var res = acc / (double) inc1.Count;
            return res;
        }

        private static List<List<long>> GetMegaShingles(IReadOnlyList<List<long>> supSh)
        {
            var res = new List<List<long>>();
            var tmp = new List<long>();

            for (var i = 0; i < supSh.Count; i++)
            for (var j = i + 1; j < supSh.Count; j++)
            {
                tmp = supSh[i];
                tmp.Concat(supSh[j]);
                res.Add(tmp);
            }
            return res;
        }
    }
}