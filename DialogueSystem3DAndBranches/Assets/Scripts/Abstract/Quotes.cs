
using UnityEngine;

namespace DialogueSystem
{
    [System.Serializable]
    public class Quotes
    {
        public CharacterSO character;
        [Space]
        public CharacterMood characterMood;
        [Space(2)]
        [TextArea]
        public string quote;
        [Header("Custom Things")]
        public float quoteDelay;
        [Space]
        public AudioClip customQuoteSFX;
        
        [Header("Additional Things")]
        public AudioClip additionalCustomSFX;


    }
}
