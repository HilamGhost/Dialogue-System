using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

namespace DialogueSystem
{
    [CustomEditor(typeof(CharacterSO))]
    public class CharacterEditor : Editor
    {
        CharacterSO character;
        private void OnEnable()
        {
            character = target as CharacterSO;
        }
        public override void OnInspectorGUI()
        {
            base.OnInspectorGUI();
            if (character.CharDefaultImage == null) 
                return;

            GetNaturalImage();
            GetHappyImage();
            GetAngryImage();
            
        }
        void GetNaturalImage() 
        {

            GUILayout.FlexibleSpace();
            EditorGUILayout.Space();
            Texture2D textureNatural = AssetPreview.GetAssetPreview(character.CharImageNatural);
            GUILayout.Label("", GUILayout.Height(121.5f), GUILayout.Width(121.5f));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), textureNatural);
            GUILayout.FlexibleSpace();

        }
        void GetHappyImage() 
        {
            EditorGUILayout.Space();
            Texture2D textureHappy = AssetPreview.GetAssetPreview(character.CharImageHappy);
            GUILayout.Label("", GUILayout.Height(121.5f), GUILayout.Width(121.5f));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), textureHappy);
            
        }
        void GetAngryImage() 
        {
            EditorGUILayout.Space();
            Texture2D textureAngry = AssetPreview.GetAssetPreview(character.CharImageAngry);
            GUILayout.Label("", GUILayout.Height(121.5f), GUILayout.Width(121.5f));
            GUI.DrawTexture(GUILayoutUtility.GetLastRect(), textureAngry);
            
        }
    }
}
