using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class DialogueStarter : MonoBehaviour
    {
        [SerializeField] DialogueSO dialogues;
        void Start()
        {
            DialogueManager.Instance.TakeQuote(dialogues.QuoteList);
        }

        
        void Update()
        {
            if (Input.GetMouseButtonDown(0)) 
            {
                DialogueManager.Instance.InteractWithDialogue();
            }
        }
    }
}
