using UnityEngine;
using UnityEngine.Serialization;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Create New Choice")]
    public class ChoiceObject : DialogueSO
    {
        [Header("Choices")] 
        public string ChoiceName;
        public string ChoiceQuote;
        public string[] ChoiceHeadings;
        public DialogueObject[] DialogueObjects;

        public override bool IsChoice() => true;
        
        public override void PlayDialogue()
        {
            DialogueManager.Instance.TakeQuote(this);
        }

        public void PlayChosenDialogue(int _number)
        {
            DialogueManager.Instance.TakeQuote(DialogueObjects[_number]);
        }
    }
}
