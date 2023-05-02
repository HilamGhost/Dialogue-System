using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Character", menuName = "Dialogue System/Create New Character")]
    public class CharacterSO : ScriptableObject
    {
        [SerializeField] string charName;

        [SerializeField] AudioClip[] characterSounds;


        public AudioClip CharSoundEffect(Quotes _currentQuote) 
        {
            if (_currentQuote.customQuoteSFX != null) return _currentQuote.customQuoteSFX;
            if (characterSounds.Length <= 0) return null;
            
                int audioClipCount = characterSounds.Length;
                int selectedSound = Random.Range(0,audioClipCount);
                return characterSounds[selectedSound];
            
        }

        public string CharName => charName;
        
    }
}
