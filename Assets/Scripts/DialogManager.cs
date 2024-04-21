// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    // Clasa pentru gestionarea dialogului in joc.
    public class DialogManager : MonoBehaviour
    {
        // Referinta catre obiectul de dialog.
        [SerializeField] GameObject dialogBox;

        // Referinta catre textul dialogului.
        [SerializeField] Text dialogText;

        // Viteza de afisare a literelor in dialog.
        [SerializeField] int lettersPerSecond;

        // Eveniment declansat la afisarea dialogului.
        public event Action OnShowDialog;

        // Eveniment declansat la ascunderea dialogului.
        public event Action OnHideDialog;

        // Dialogul curent.
        Dialog dialog;

        // Linia curenta din dialog.
        int currentLine;

        // Variabila pentru a verifica daca se tasteaza in dialog.
        bool isTyping;

        // Proprietate statica pentru accesul la instanta clasei.
        public static DialogManager Instance
        {
            get;

            private set;
        }
        
        // Metoda apelata la initializarea obiectului.
        private void Awake()
        {
            Instance = this;
        }

        // Metoda pentru afisarea dialogului.
        public IEnumerator ShowDialog(Dialog dialog)
        {
            // Initializarea variabilelor pentru afisarea dialogului.
            currentLine = 0;

            yield return new WaitForEndOfFrame();

            OnShowDialog?.Invoke();

            this.dialog = dialog;

            dialogBox.SetActive(true);

            // Afisarea dialogului.
            StartCoroutine(TypeDialog(dialog.Lines[0]));
        }

        // Metoda apelata pentru tratarea input-ului in timpul dialogului.
        public void HandleUpdate()
        {
            if (Input.GetKeyUp(KeyCode.Space) && !isTyping)
            {
                ++currentLine;

                // Daca mai exista linii de dialog, afiseaza urmatoarea.
                if (currentLine < dialog.Lines.Count)
                    StartCoroutine(TypeDialog(dialog.Lines[currentLine]));

                // Altfel, ascunde caseta de dialog.
                else
                {
                    dialogBox.SetActive(false);

                    OnHideDialog?.Invoke();
                }
            }
        }

        // Metoda pentru afisarea graduala a textului in dialog.
        public IEnumerator TypeDialog(string line)
        {
            isTyping = true;

            dialogText.text = "";

            // Afisarea fiecarei litere la un interval de timp dat.
            foreach (var letter in line.ToCharArray())
            {
                dialogText.text += letter;

                yield return new WaitForSeconds(1f / lettersPerSecond);
            }
            isTyping = false;
        }
    }
}
