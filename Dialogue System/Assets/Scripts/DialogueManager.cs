using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DialogueSystem
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        [SerializeField] bool isOpen;
        [SerializeField] bool isContinuing;
        [SerializeField] int currentQuote;

        List<Quotes> quotes;

        [SerializeField] string currentText = "";
        [SerializeField] float delay = 0.1f;
        [Header("UI")]
        [SerializeField] GameObject dialogueGO;
        [SerializeField] Image dialogueBG;
        [SerializeField] TextMeshProUGUI nameText;
        [SerializeField] TextMeshProUGUI quoteText;
        [SerializeField] Image charPortrait;

        [SerializeField] AudioSource dialogueAudioSource;
        [SerializeField] AudioSource additionalDialogueAudioSource;

        private DialogueEmotionManager dialogueEmotionManager;
        [SerializeField] private List<string> emotionWordList;
        [SerializeField] private List<string> clearQuote;
        private Dictionary<string, string> emotionWordDictionary = new Dictionary<string, string>();


        #region Properties
        public bool IsOpen => isOpen;
        #endregion

        #region Take Quote

        /// <summary>
        /// Starts the Dialogue on UI
        /// </summary>
        public void TakeQuote(List<Quotes> quoteLists)
        {
            isOpen = true;
            quotes = quoteLists;

            dialogueGO.SetActive(true);
            StartCoroutine(StartDialogue(quotes[currentQuote]));
        }
        
        #endregion

        #region AssignmentSetters

        protected override void Awake()
        {
            base.Awake();
            SetAssignments();
        }

        void SetAssignments()
        {
            dialogueEmotionManager = new DialogueEmotionManager();
        }
        

        #endregion
        private void Update()
        {
            quoteText.text = currentText;
        }
        
        IEnumerator StartDialogue(Quotes quote)
        {
            var emotionWords = quote.quote.GetQuoteEmotions(ref emotionWordDictionary);
            var clearTextList = quote.quote.GetClearText();
            dialogueEmotionManager.GetEmotionWordDictionary(emotionWordDictionary);
            
            clearQuote = clearTextList;
            emotionWordList = emotionWords;

            
            
            
            var _quoteDelay = delay;
            if (quote.quoteDelay > 0) _quoteDelay = quote.quoteDelay;

            nameText.text = quote.character.CharName;
            SetDialogueImage(quote);

            SoundManager.Instance.PlayOneShot(additionalDialogueAudioSource,quote.additionalCustomSFX);
            
            isContinuing = true;
           
            for (int i = 0; i < clearTextList.Count; i++)
            {
                string _nextWord = clearTextList[i];

                //Emotion Check
                if (_nextWord.HasWordGotEmotion(emotionWords))
                {
                    currentText += dialogueEmotionManager.ApplyEmotion(_nextWord,quote);
                    yield return new WaitForSeconds(dialogueEmotionManager.ChangeQuoteDelay(_quoteDelay));
                    continue;
                }
                
                // Dacticlo Effect
                for (int j = 0; j < _nextWord.Length; j++)
                {
                    currentText += _nextWord[j];
                    SetDialogueSound(quote);

                    yield return new WaitForSeconds(_quoteDelay);
                }

            }
            isContinuing = false;
        }
        
        

        /// <summary>
        /// Closes the Dialogue or Skips the Quote
        /// </summary>
        public void InteractWithDialogue()
        {
            if (isOpen) 
            {
                if (isContinuing)
                {
                    StopAllCoroutines();
                    currentText = GetClearQuote(clearQuote,quotes[currentQuote]);
                    isContinuing = false;
                    return;
                }
                
                currentQuote++; 
                currentText = "";
                nameText.text = "";
                dialogueEmotionManager.ResetEmotionWordDictionary();

                if (currentQuote < quotes?.Count) 
                { 
                    StartCoroutine(StartDialogue(quotes[currentQuote]));
                    return;
                }
                
                currentQuote = 0; 
                currentText = "";
                nameText.text = "";
                dialogueGO.SetActive(false);
                isOpen = false;
            }
           
        }
        
        public string GetClearQuote(List<string> clearTexts,Quotes quote)
        {
            string fullQuote = "";
            
            foreach (var word in clearTexts)
            {
                if (word.HasWordGotEmotion(emotionWordList))
                {
                    currentText += dialogueEmotionManager.ApplyEmotion(fullQuote,quote);
                    continue;
                }
                fullQuote += word;
            }

            return fullQuote;
        }
        
        /// <summary>
        /// Sets Dialogue Image 
        /// </summary>
        void SetDialogueImage(Quotes _currentQuote)
        {
            charPortrait.sprite = _currentQuote.character.CharImage(_currentQuote);
            
            if (_currentQuote.character.IsCharacterLookingLeftByDefault) charPortrait.rectTransform.localScale = new Vector3(-1, 1, 1);
            else charPortrait.rectTransform.localScale = new Vector3(1, 1, 1);

            if (_currentQuote.isCharacterLookingLeft)
            {
                dialogueBG.rectTransform.localScale = new Vector3(-1, 1, 1);
                nameText.rectTransform.localScale = new Vector3(-1, 1, 1);
                quoteText.rectTransform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                dialogueBG.rectTransform.localScale = new Vector3(1, 1, 1);

               
                nameText.rectTransform.localScale = new Vector3(1, 1, 1);
                quoteText.rectTransform.localScale = new Vector3(1, 1, 1);
            }

        }

        public void SetDialogueSound(Quotes quote) 
        {
            if (currentText.Length > 1 && currentText[currentText.Length - 1] != ' ')
                SoundManager.Instance.PlayOneShot(dialogueAudioSource, quote.character.CharSoundEffect(quote));
        }
    }
}
