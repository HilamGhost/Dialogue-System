using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Create New Dialogue")]
    public class DialogueObject : DialogueSO
    {
        [SerializeField] List<Quotes> quoteList;
        public List<Quotes> QuoteList => quoteList;

        public UnityEvent eventsAfterDialogue;

        public override bool IsChoice() => false;
       
        public override void PlayDialogue()
        {
            DialogueManager.Instance.TakeQuote(this);
        }

        public void PlayAfterEvents()
        {
            eventsAfterDialogue.Invoke();
        }
    }
}
