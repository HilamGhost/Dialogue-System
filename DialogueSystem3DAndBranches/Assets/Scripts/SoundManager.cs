using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    public class SoundManager : Singleton<SoundManager>
    {
        public void PlayOneShot(AudioSource _audio,AudioClip _audioClip) 
        {
            if (_audioClip == null )return;
            
            _audio?.PlayOneShot(_audioClip);
        }
    }
}
