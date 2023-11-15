using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueEmotionManager
    {
        private DialogueManager dialogueManager;   
        private Dictionary<string, string> emotionWordDictionary;
        
        
        //Extras
        private float quoteDelay = -1;
        public DialogueEmotionManager()
        {
            dialogueManager = DialogueManager.Instance;
        }

        #region Set Dictionary

        public void GetEmotionWordDictionary(Dictionary<string, string> _emotionWordDictionary)
        {
            emotionWordDictionary = _emotionWordDictionary;
            foreach (var word in emotionWordDictionary)
            {
                Debug.Log("Word =>".AddColor(Color.green) + word.Key + " Emotion=>".AddColor(Color.red) + word.Value);
            } 
        }

        public void ResetEmotionWordDictionary()
        {
            emotionWordDictionary.Clear();
            Debug.Log("--------- Dictionary Cleaned------------");
        }

        #endregion

        public string ApplyEmotion(string word,Quotes quote)
        {
            string _emotion = FindTheEmotion(word);
            string _result;
           
            switch (_emotion)
            {
                case "anger":
                    _result = ApplyAnger(word,quote);
                    break;
                case "delay":
                    _result= ApplyDelay(word,quote);
                    break;
                default: 
                    _result = " "; 
                    break;
            }

            return _result;
        }
        string FindTheEmotion(string word)
        {
            Debug.Log("a"+word);
            if(emotionWordDictionary.ContainsKey(word)) return emotionWordDictionary[word];
            return "";
        }
        #region Emotion Functions

        string ApplyAnger(string word,Quotes quote)
        {
            string _word = word.AddColor(Color.red);
            dialogueManager.SetDialogueSound(quote);
            return _word;
        }

        string ApplyDelay(string word,Quotes quote)
        {
            if(float.TryParse(word, out float _delay))
            {
                quoteDelay = _delay/10;
            }
            return " ";
        }
        #endregion

        #region Extra Functions

        public float ChangeQuoteDelay(float _normalDelay)
        {
            if (Mathf.Approximately(quoteDelay, -1)) return _normalDelay;

            float _wantedDelay = quoteDelay;
            quoteDelay = -1;

            return _wantedDelay;
        }
        

        #endregion
    }
}
