using UnityEngine;

namespace DialogueSystem
{
    public abstract class DialogueSO : ScriptableObject
    {
        public abstract bool IsChoice();
        public abstract void PlayDialogue();

    }
}
