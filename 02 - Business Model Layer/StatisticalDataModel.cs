using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbProject
{
    public class StatisticalDataModel
    {
        public string LongestWord { get; set; }
        public string ShortestWord { get; set; }
        public float WordsAvgLength { get; set; }
        public int HowMuchWordsInTheSong { get; set; }
        public List<string?> wordsAppearsTheMostInTheSong { get; set;}
        public List<int> howMuchWordsInVerses { get; set; }
        public List<int> howMuchWordsInSentences { get; set; }


        public StatisticalDataModel() {
        }


    }
}
