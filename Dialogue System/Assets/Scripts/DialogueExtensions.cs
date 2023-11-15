
using System.Collections.Generic;
namespace DialogueSystem
{
    public static class DialogueExtensions
    {
        #region Assigners
        
        public static List<string> GetQuoteEmotions(this string _quote, ref Dictionary<string,string> emotionDictionary)
        {
            string[] subTexts = _quote.Split('[',']');
            List<string> realEmotionList= new List<string>();
            
            for (int i = 0; i < subTexts.Length; i++)
            {
                if (!HasWordEmotion(subTexts[i])) continue;

                AddEmotionWordToDictionary(subTexts[i],ref emotionDictionary);
                var pureText = RemoveWordEmotion(subTexts[i]);
                
                realEmotionList.Add(pureText);
            }

            return realEmotionList;
        }

        public static List<string> GetClearText(this string _quote)
        {
            string[] subTexts = _quote.Split('[',']');
            List<string> clearWordList= new List<string>();
            
            for (int i = 0; i < subTexts.Length; i++)
            {
                if(subTexts[i] == "") continue;
                
                if (!HasWordEmotion(subTexts[i]))
                {
                    clearWordList.Add(subTexts[i]);
                    continue;
                }
                
                var pureText = RemoveWordEmotion(subTexts[i]);
                
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
        static void AddEmotionWordToDictionary(string _word,ref Dictionary<string,string> emotionDictionary)
        {
            var _subTexts =_word.Split('=');
            
            var _dicKey=_subTexts[1].TrimStart();
            var _dicValue= _subTexts[0].Replace(" ", "");
            
            emotionDictionary.Add(_dicKey,_dicValue);
        }
        #endregion
        
        static bool HasWordEmotion(string _word)
        {
            return _word.StartsWith("anger= ")|| _word.StartsWith("delay= ");
        }
        
        static string RemoveWordEmotion(string _word)
        {
           if(_word.StartsWith("anger= ")) return _word.Replace("anger= ","");
           if(_word.StartsWith("delay= ")) return _word.Replace("delay= ","");;


           return "";
        }
        
      
        
  
    }
}
