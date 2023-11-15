using TMPro;
using UnityEngine;

namespace DialogueSystem
{
    public class TexMeshProEffects : MonoBehaviour
    {
        [SerializeField] private TMP_Text textComponent;

        // Update is called once per frame
        void Update()
        {
            textComponent.ForceMeshUpdate();
            var quoteTextInfo = textComponent.textInfo;
            for (int i = 0; i < quoteTextInfo.characterCount; i++)
            {
                var _charInfo = quoteTextInfo.characterInfo[i];

                if (!_charInfo.isVisible) continue;

                var verts = quoteTextInfo.meshInfo[_charInfo.materialReferenceIndex].vertices;
                for (int j = 0; j < 4; j++)
                {
                    var orig = verts[_charInfo.vertexIndex + j];
                    verts[_charInfo.vertexIndex + j] =
                        orig + new Vector3(0, Mathf.Sin(Time.time - 2 + orig.x * 0.01f) * 10, 0);
                }
            }
            for (int i = 0; i < quoteTextInfo.meshInfo.Length; i++)
            {
                var meshInfo = quoteTextInfo.meshInfo[i];
                meshInfo.mesh.vertices = meshInfo.vertices;
                textComponent.UpdateGeometry(meshInfo.mesh, i);
            }
        }
        public int CheckWordStart(string _wantedWord)
        {
            if (textComponent.text == _wantedWord)
            {
                
            }
            return 0;
        }
        
    }
}
