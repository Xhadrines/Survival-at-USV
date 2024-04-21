using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SurvivalAtUSV
{
    public class DialogManager : MonoBehaviour
    {
        [SerializeField] GameObject dialogBox;
        [SerializeField] Text dialogText;
        [SerializeField] int lettersPerSecond;

        public event Action OnShowDialog;
        public event Action OnHideDialog;

        Dialog dialog;

        int currentLine;

        bool isTyping;

        public static DialogManager Instance
        {
            get;
            private set;
        }
        
        private void Awake()
        {
            Instance = this;
        }

        public IEnumerator ShowDialog(Dialog dialog)
        {
            currentLine = 0;

            yield return new WaitForEndOfFrame();

            OnShowDialog?.Invoke();

            this.dialog = dialog;

            dialogBox.SetActive(true);

            StartCoroutine(TypeDialog(dialog.Lines[0]));
        }

        public void HandleUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space) && !isTyping)
            {
                ++currentLine;

                if (currentLine < dialog.Lines.Count)
                    StartCoroutine(TypeDialog(dialog.Lines[currentLine]));
                
                else
                {
                    dialogBox.SetActive(false);

                    OnHideDialog?.Invoke();
                }
            }
        }

        public IEnumerator TypeDialog(string line)
        {
            isTyping = true;

            dialogText.text = "";

            foreach (var letter in line.ToCharArray())
            {
                dialogText.text += letter;

                yield return new WaitForSeconds(1f / lettersPerSecond);
            }
            isTyping = false;
        }
    }
}
