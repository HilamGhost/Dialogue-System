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

        [SerializeField] AudioClip[] characterSounds;

        [Header("Mood Portraits")]
        [SerializeField] Sprite charImageNatural;
        [SerializeField] Sprite charImageHappy;
        [SerializeField] Sprite charImageAngry;

        public Sprite CharImage(Quotes _currentQuote)
        {
            if (_currentQuote.hasCustomPortrait) 
            {
                return _currentQuote.customQuotePortrait;
            }
            else 
            {
                switch (_currentQuote.characterMood)
                {
                    default: Debug.LogError("THERE IS NO MOOD"); return null; break;
                    case CharacterMood.Natural: return charImageNatural; break;
                    case CharacterMood.Happy: return charImageHappy; break;
                    case CharacterMood.Angry: return charImageAngry; break;
                }
            }         
        }
        public AudioClip CharSoundEffect(Quotes _currentQuote) 
        {
            if (_currentQuote.hasCustomSFX) return _currentQuote.customQuoteSFX;
            else 
            {
                int audioClipCount = characterSounds.Length;
                int selectedSound = Random.Range(0,audioClipCount);
                return characterSounds[selectedSound];
            }
        }

        public string CharName => charName;
        public bool IsCharacterLookingLeftByDefault => isCharacterLookingLeftByDefault;
        public Sprite CharDefaultImage => charImage;
        

        #region Mood Properties
        public Sprite CharImageNatural => charImageNatural;
        public Sprite CharImageHappy => charImageHappy;
        public Sprite CharImageAngry => charImageAngry;
        #endregion
    }
}
