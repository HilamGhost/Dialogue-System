using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.Serialization;

namespace DialogueSystem
{
    public class DialogueManager : Singleton<DialogueManager>
    {
        [SerializeField] bool isDialogueOpen;
        [SerializeField] bool isContinuing;
        [SerializeField] int currentQuote;
       
        List<Quotes> quotes;

        [SerializeField] string currentText = "";
        [SerializeField] float delay = 0.1f;
        
        [Header("UI For Dialogue")]
        [SerializeField] GameObject dialogueGO;
        [SerializeField] TextMeshProUGUI nameDialgoueText;
        [SerializeField] TextMeshProUGUI quoteDialogueText;
        [SerializeField] private DialogueObject activeDialogueObject;
        
        
        [Header("UI For Choice")]
        [SerializeField] GameObject choiceGO;
        [SerializeField] TextMeshProUGUI nameChoiceText;
        [SerializeField] TextMeshProUGUI quoteChoiceText;
        [SerializeField] private TextMeshProUGUI[] buttonsText;
        [SerializeField] private ChoiceObject activeChoiceObject;
        
        [SerializeField] AudioSource dialogueAudioSource;
        [SerializeField] AudioSource additionalDialogueAudioSource;

        [Header("Leave Conversation")] 
        [SerializeField] private DialogueObject leaveQuote;

        [Space(60)] 
        [Header("Characters")] 
        [SerializeField] private NPC[] characters;
        


        #region Properties
        public bool IsDialogueOpen => isDialogueOpen;
        #endregion
        
        private void Update()
        {
            quoteDialogueText.text = currentText;
        }
        IEnumerator StartDialogue(Quotes quote)
        {
            var _quoteDelay = delay;
            if (quote.quoteDelay > 0) _quoteDelay = quote.quoteDelay;

            nameDialgoueText.text = quote.character.CharName;

            SoundManager.Instance.PlayOneShot(additionalDialogueAudioSource,quote.additionalCustomSFX);
            PlayCharacterAnimations();
            
            isContinuing = true;
            
            for (int i = 0; i < quote.quote.Length + 1; i++)
            {
                currentText = quote.quote.Substring(0, i);
                SetDialogueSound(quote);
                
                yield return new WaitForSeconds(_quoteDelay);
            }
            
            isContinuing = false;
        }

        #region Public Access Methots
        
        /// <summary>
        /// Starts the Dialogue on UI
        /// </summary>
        public void TakeQuote(DialogueObject _activeDialogueObject)
        {
            activeDialogueObject = _activeDialogueObject;
            
            isDialogueOpen = true;
            quotes = _activeDialogueObject.QuoteList;

            dialogueGO.SetActive(true);
            StartCoroutine(StartDialogue(quotes[currentQuote]));
        }
        
        /// <summary>
        /// Starts the Choice on UI
        /// </summary>
        public void TakeQuote(ChoiceObject _choiceObject)
        {
            activeDialogueObject = null;
            
            nameChoiceText.text = _choiceObject.ChoiceName;
            quoteChoiceText.text = _choiceObject.ChoiceQuote;
            
            for (int i = 0; i < 3; i++)
            {
                buttonsText[i].text = _choiceObject.ChoiceHeadings[i];
            }

            activeChoiceObject = _choiceObject;
            choiceGO.SetActive(true);
        }
        /// <summary>
        /// Closes the Dialogue or Skips the Quote
        /// </summary>
        public void InteractWithDialogue()
        {
            if (isDialogueOpen) 
            {
                if (isContinuing)
                {
                    StopAllCoroutines();
                    currentText = quotes[currentQuote].quote;
                    isContinuing = false;
                }
                else
                {
                    currentQuote++;
                    currentText = "";
                    nameDialgoueText.text = "";

                    if (currentQuote < quotes?.Count)
                    {
                        StartCoroutine(StartDialogue(quotes[currentQuote]));
                    }
                    else
                    {
                        FinishQuote();
                    }
                }
            }
           
        }
        #endregion
        #region Finish Methods
        void FinishQuote()
        {
            currentQuote = 0;
            
            currentText = "";
            nameDialgoueText.text = "";
            
            dialogueGO.SetActive(false);
            isDialogueOpen = false;
            
           
            activeDialogueObject.PlayAfterEvents();

        }
        void FinishQuoteWithoutEvent()
        {
            currentQuote = 0;
            
            currentText = "";
            nameDialgoueText.text = "";
            
            dialogueGO.SetActive(false);
            isDialogueOpen = false;

        }
        

        #endregion
        
        #region Choice Methods
        public void SetChoiceDialogue(int i)
        {
            choiceGO.SetActive(false);

            activeChoiceObject.PlayChosenDialogue(i);
            activeChoiceObject = null;
        }
        

        #endregion
        
        #region Leave Dialogue Methods

        public void LeaveDialogue()
        {
            FinishQuoteWithoutEvent();
            StopAllCoroutines();
            currentText = "";
            choiceGO.SetActive(false);
            isContinuing = false;
            
           
            activeChoiceObject = null;
            
            leaveQuote.PlayDialogue();
        }

        #endregion

        #region Character Methods
        public string CharacterMood()
        {
            if (!activeDialogueObject) return "";

            string _moodName = "";
            
            switch (activeDialogueObject.QuoteList[currentQuote].characterMood)
            {
                case DialogueSystem.CharacterMood.Natural:
                    _moodName = "Natural"; break;
                case DialogueSystem.CharacterMood.Happy: 
                    _moodName = "Happy";
                    break;
                case DialogueSystem.CharacterMood.Angry:
                    _moodName = "Angry";
                    break;
            }

            return _moodName;
        }

        void PlayCharacterAnimations()
        {
            foreach (var _character in characters)
            {
                if (_character.transform.name == activeDialogueObject.QuoteList[currentQuote].character.CharName)
                {
                    _character.PlayAnimation();
                    break;
                }
            }
        }
        

        #endregion
       
        void SetDialogueSound(Quotes quote) 
        {
            if (currentText.Length > 1 && currentText[currentText.Length - 1] != ' ')
                SoundManager.Instance.PlayOneShot(dialogueAudioSource, quote.character.CharSoundEffect(quote));
        }
    }
}
