using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace DialogueSystem
{
    public class EndGame : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI result;
        [Space(30)] 
        [SerializeField] private string failStatus;
        [SerializeField] private string winStatus;
        private Animator _animator;
        private void Start()
        {
            _animator = GetComponent<Animator>();
        }

        public void WriteResult(bool _isWin)
        {
            _animator.SetTrigger("End");
            if (_isWin)
                result.text = winStatus;
            else
                result.text = failStatus;
            
            Invoke("WriteText",2);
            Invoke("RestartGame",4);
        }

        void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

        void WriteText()=> result.enabled = true;
      
    }
}
