using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    public class DialogueGraphView : GraphView
    {
        readonly Vector2 defaultNodeSize = new Vector2(150,200);
        public DialogueGraphView()
        {
            this.AddManipulator(new ContentDragger());
            this.AddManipulator(new SelectionDragger());
            this.AddManipulator(new RectangleSelector());
            AddElement(GenerateEntryPointNode());
        }
        Port GeneratePort(DialogueNode node,Direction portDirection, Port.Capacity capacity = Port.Capacity.Single) 
        {
            return node.InstantiatePort(Orientation.Horizontal,portDirection,capacity,typeof(float));
        }
        DialogueNode GenerateEntryPointNode() 
        {
            var node = new DialogueNode
            {
                title = "START",
                GUID = Guid.NewGuid().ToString(),
                DialogueText = "ENTRYPOINT",
                EntryPoint = true
                
            };
            var generatedPort = GeneratePort(node,Direction.Output);
            generatedPort.portName = "Next";
            node.outputContainer.Add(generatedPort);

            node.RefreshExpandedState();
            node.RefreshPorts();

            node.SetPosition(new Rect(100,200,100,150));
            return node;
        }

        public DialogueNode CreateDialogueNode(string nodeName) 
        {
            var dialogueNode = new DialogueNode
            {
                title = nodeName,
                DialogueText = nodeName,
                GUID = Guid.NewGuid().ToString()
            };
            var _inputPort = GeneratePort(dialogueNode, Direction.Input, Port.Capacity.Multi);
            _inputPort.portName = "Input";
            dialogueNode.inputContainer.Add(_inputPort);
            dialogueNode.RefreshExpandedState();
            dialogueNode.RefreshPorts();
            dialogueNode.SetPosition(new Rect(Vector2.zero,defaultNodeSize));
            
            return dialogueNode;
        }
    }
}
