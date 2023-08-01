using System;
using System.Collections.Generic;

namespace TextAnalysis
{
    static class SentencesParserTask
    {
        public static List<List<string>> ParseSentences(string text)
        {
            var sentencesList = new List<List<string>>();
            var symbolsToCheck = ".!?;:()";
            var shouldAddNewList = true;
            var shouldAddToExistedWord = false;
            
            for (int i = 0; i < text.Length; i++)
            {
                var item = char.ToLower(text[i]);
                
                if (char.IsLetter(item) || item == '\'')
                {
                    if (shouldAddNewList)
                    {
                        sentencesList.Add(new List<string> { item.ToString() });
                    }
                    else if (shouldAddToExistedWord)
                    {
                        var index = sentencesList.Count - 1;
                        if (sentencesList[index].Count == 0)
                        {
                            sentencesList[index].Add(item.ToString());
                        }
                        else
                        {
                            sentencesList[index][sentencesList[index].Count - 1] += item.ToString();
                        }
                    }
                    else
                    {
                        sentencesList[sentencesList.Count - 1].Add(item.ToString());
                    }

                    shouldAddNewList = false;
                    shouldAddToExistedWord = true;
                }
                else if (symbolsToCheck.Contains(item.ToString()))
                {
                    shouldAddNewList = true;
                }
                else
                {
                    shouldAddToExistedWord = false;
                }
            }
            
            return sentencesList;
        }
    }
}