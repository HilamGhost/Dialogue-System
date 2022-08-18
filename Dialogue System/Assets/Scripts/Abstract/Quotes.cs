using System.Collections;
using System.Collections.Generic;
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
        [Space]
        public bool isCharacterLookingLeft; // If is false player is looking RIGHT
        [Header("Custom Things")]
        public float quoteDelay;
        [Space]
        public bool hasCustomSFX;
        public AudioClip customQuoteSFX;
        [Space]
        public bool hasCustomPortrait;
        public Sprite customQuotePortrait;
        
        [Header("Additional Things")]
        public AudioClip additionalCustomSFX;


    }
}
