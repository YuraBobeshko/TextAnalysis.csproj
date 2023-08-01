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
                if (char.IsLetter(text[i]))
                {
                    if (shouldAddNewList)
                    {
                        sentencesList.Add(new List<string>(text[i]));
                    } 
                    else if (shouldAddToExistedWord)
                    {
                        var index = sentencesList.Count - 1;
                        if (sentencesList[index].Count == 0)
                        {
                            sentencesList[index][sentencesList[index].Count] = text[i].ToString();
                        } 
                        else
                        {
                            sentencesList[index][sentencesList[index].Count - 1] += text[i].ToString();
                        }
                    } 
                    else
                    {
                        sentencesList[sentencesList.Count - 1].Add(text[i].ToString());
                    }

                    shouldAddNewList = false;
                    shouldAddToExistedWord = true;
                } 
                else if (symbolsToCheck.Contains(text[i].ToString()) )
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