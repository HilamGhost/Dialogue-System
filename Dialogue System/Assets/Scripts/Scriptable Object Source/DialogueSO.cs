using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DialogueSystem
{
    [CreateAssetMenu(fileName = "New Dialogue", menuName = "Dialogue System/Create New Dialogue")]
    public class DialogueSO : ScriptableObject
    {
        [SerializeField] List<Quotes> quoteList;

        public List<Quotes> QuoteList => quoteList;


    }
}
