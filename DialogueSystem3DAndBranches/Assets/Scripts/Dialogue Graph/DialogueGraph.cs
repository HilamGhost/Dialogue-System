using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEditor.Experimental.GraphView;
using UnityEditor.UIElements;
using UnityEngine.UIElements;

namespace DialogueSystem
{
    public class DialogueGraph : EditorWindow
    {
        //14:59
        DialogueGraphView _graphView;

        [MenuItem("Graph/Dialogue Graph")]
        public static void OpenDialogueGraphWindow() 
        {
            var window = GetWindow<DialogueGraph>();
            window.titleContent = new GUIContent("Dialogue Graph");
        }
        private void OnEnable()
        {
            ConstructGraphView();
            GenerateToolbar();
        }
        private void OnDisable()
        {
            rootVisualElement.Remove(_graphView);
        }
        void GenerateToolbar() 
        {
            var toolbar = new Toolbar();

            var nodeCreateButton = new Button ( () =>  {  _graphView.CreateDialogueNode("Dialogue Node"); } );
            nodeCreateButton.text = "Create Node";
            toolbar.Add(nodeCreateButton);

            rootVisualElement.Add(toolbar);
            
        }
        void ConstructGraphView() 
        {

            _graphView = new DialogueGraphView
            {
                name = "Dialogue Graph"
            };
            _graphView.StretchToParentSize();
            rootVisualElement.Add(_graphView);
        }
    }
}
