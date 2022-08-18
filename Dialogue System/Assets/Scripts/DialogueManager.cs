using System.Collections;
using System.Collections.Generic;
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
        [SerializeField] Text nameText;
        [SerializeField] Text quoteText;
        [SerializeField] Image charPortrait;

        [SerializeField] AudioSource dialogueAudioSource;
        [SerializeField] AudioSource additionalDialogueAudioSource;


        #region Properties
        public bool IsOpen => isOpen;
        #endregion


        private void Start()
        {

        }
        private void Update()
        {
            quoteText.text = currentText;
        }
        IEnumerator StartDialogue(Quotes quote)
        {
            var _quoteDelay = delay;
            if (quote.quoteDelay > 0) _quoteDelay = quote.quoteDelay;

            nameText.text = quote.character.CharName;
            SetDialogueImage(quote);

            SoundManager.Instance.PlayOneShot(additionalDialogueAudioSource,quote.additionalCustomSFX);
            
            isContinuing = true;
            
            for (int i = 0; i < quote.quote.Length + 1; i++)
            {
                currentText = quote.quote.Substring(0, i);
                SetDialogueSound(quote);

                yield return new WaitForSeconds(_quoteDelay);
            }
            
            isContinuing = false;
        }
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
                    currentText = quotes[currentQuote].quote;
                    isContinuing = false;
                }
                else
                {
                    currentQuote++;
                    currentText = "";
                    nameText.text = "";

                    if (currentQuote < quotes?.Count)
                    {
                        StartCoroutine(StartDialogue(quotes[currentQuote]));
                    }
                    else
                    {
                        currentQuote = 0;
                        currentText = "";
                        nameText.text = "";
                        dialogueGO.SetActive(false);
                        isOpen = false;

                    }
                }
            }
           
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

        void SetDialogueSound(Quotes quote) 
        {
            if (currentText.Length > 1 && currentText[currentText.Length - 1] != ' ')
                SoundManager.Instance.PlayOneShot(dialogueAudioSource, quote.character.CharSoundEffect(quote));
        }
    }
}
