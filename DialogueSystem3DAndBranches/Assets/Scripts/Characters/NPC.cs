using UnityEngine;

namespace DialogueSystem
{
    [RequireComponent(typeof(Animator))]
    public abstract class NPC : MonoBehaviour
    {
        public abstract void PlayAnimation();
    }
}
