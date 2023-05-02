using System;
using UnityEngine;
using Random = UnityEngine.Random;

namespace DialogueSystem
{
    public class Marley : NPC
    {
        private Animator marvinAnimator;

        private void Awake()
        {
            marvinAnimator = GetComponent<Animator>();
        }
        

        public void SetMarleyAnimation()
        {
            marvinAnimator.SetFloat("randomInt",Mathf.Round(Random.Range(0,3)));
            marvinAnimator.SetTrigger(DialogueManager.Instance.CharacterMood());
        }

        public override void PlayAnimation()
        {
            SetMarleyAnimation();
        }
        
    }
}
