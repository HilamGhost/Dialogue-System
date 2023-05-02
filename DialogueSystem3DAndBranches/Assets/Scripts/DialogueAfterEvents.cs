using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue After Events", menuName = "Dialogue System/Create New Events")]
    public class DialogueAfterEvents : ScriptableObject
    {
        public void WriteDebugMessage(string _message)
        {
            Debug.Log(_message);
        }

        public void PlayNextDialogue(DialogueSO _dialogue)
        {
            _dialogue.PlayDialogue();
        }

        public void LeaveGame(bool _isWin)
        {
            EndGame endGameObject = FindObjectOfType<EndGame>().GetComponent<EndGame>();
            endGameObject.WriteResult(_isWin);
        }
    }
}
