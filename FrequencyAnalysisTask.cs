using System;
using System.Collections.Generic;
using System.Linq;

namespace TextAnalysis
{
    static class FrequencyAnalysisTask
    {
        public static Dictionary<string, string> GetMostFrequentNextWords(List<List<string>> text)
        {
            var result = new Dictionary<string, string>();
            
            for (int i = 0; i < text.Count; i++)
            {
                var line = text[i];
                for (int j = 0; j < line.Count; j++)
                {
                    var word = line[j];
                    if (line.Count - 1 <= j) continue;

                    if (result.ContainsKey(word))
                    {
                        if (string.CompareOrdinal(line[j + 1], result[word]) < 0)
                        {
                            result[word] = line[j + 1];
                        }
                    }
                    else
                    {
                        result.Add(word, line[j + 1]);
                    }
                    

                    if (j != 0 && j % 2 != 0 && !result.ContainsKey(line[j - 1] + " " + word))
                    {
                        result.Add(line[j - 1] + " " + word, line[j + 1]);
                    }
                }
            }
            
            return result;
        }
   }
}