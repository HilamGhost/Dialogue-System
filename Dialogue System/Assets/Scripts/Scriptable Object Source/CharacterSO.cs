using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Dialogue System/Create New Character")]
    public class CharacterSO : ScriptableObject
    {
        [SerializeField] Sprite charImage;
        [SerializeField] string charName;
        [SerializeField] bool isCharacterLookingLeftByDefault;

        [Header("Mood Portraits")]
        [SerializeField] Sprite charImageNatural;
        [SerializeField] Sprite charImageHappy;
        [SerializeField] Sprite charImageAngry;

        public Sprite CharImage(Quotes _currentQuote)
        {
            switch (_currentQuote.characterMood) 
            {
                default: Debug.LogError("THERE IS NO MOOD"); return null; break;
                case CharacterMood.Natural:return charImageNatural; break;
                case CharacterMood.Happy: return charImageHappy; break;
                case CharacterMood.Angry: return charImageAngry; break;
            }
        }

        public string CharName => charName;
        public bool IsCharacterLookingLeftByDefault => isCharacterLookingLeftByDefault;
    }
}