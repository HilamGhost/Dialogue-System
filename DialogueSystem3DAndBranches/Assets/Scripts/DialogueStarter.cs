using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] DialogueObject firstDialogue;
        [SerializeField] private GameObject startMenuScreen;
        [SerializeField] private GameObject leaveButton;
        [SerializeField] private Marley _marley;
        private int currentQuoteCount;
        
        
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                DialogueManager.Instance.InteractWithDialogue();
            }
        }

        public void StartGame()
        {
            startMenuScreen.SetActive(false);
            leaveButton.SetActive(true);
            
            _marley.gameObject.SetActive(true);
            Invoke("StartDialogueGame",2);
        }

        void StartDialogueGame()
        {
            DialogueManager.Instance.TakeQuote(firstDialogue);
        }
    }
}
