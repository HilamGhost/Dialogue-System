using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DialogueSystem
{
    public static class DialogueExpressionExtensions
    {
        public static List<string> GetQuoteEmotions(this string _quote)
        {
            string[] subTexts = _quote.Split('[',']');
            List<string> realEmotionList= new List<string>();
            
            for (int i = 0; i < subTexts.Length; i++)
            {
                if (!subTexts[i].StartsWith("emotion= ")) continue;
                
                var pureText = subTexts[i].Replace("emotion= ","");
                
                realEmotionList.Add(pureText);
            }

            return realEmotionList;
        }

        public static List<string> GetClearText(this string _quote,List<string> emotionWords = null)
        {
            if (emotionWords == null) emotionWords = _quote.GetQuoteEmotions();
            string[] subTexts = _quote.Split('[',']');
            List<string> clearWordList= new List<string>();
            
            for (int i = 0; i < subTexts.Length; i++)
            {
                if (!subTexts[i].StartsWith("emotion= "))
                {
                    clearWordList.Add(subTexts[i]);
                    continue;
                }
                
                var pureText = subTexts[i].Replace("emotion= ","");
                
                clearWordList.Add(pureText);
            }

            return clearWordList;
        }

        public static bool HasWordGotEmotion(this string _quote, List<string> emotionWords)
        {
            bool hasGotEmotion = false;
            for (int i = 0; i < emotionWords.Count; i++)
            {
                if (_quote == emotionWords[i])
                {
                    hasGotEmotion = true;
                    break;
                }
            }

            return hasGotEmotion;
        }
    }
}
