using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Experimental.GraphView;

namespace DialogueSystem
{
    public class DialogueNode : Node
    {
        public string GUID;

        public string DialogueText;

        public bool EntryPoint = false;
    }
}
