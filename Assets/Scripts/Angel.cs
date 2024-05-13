using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public class Angel : MonoBehaviour, Interactable
    {
        // Dialogul asociat personajului.
        [SerializeField] Dialog dialog;

        // Metoda pentru a interactiona cu jucatorul.
        public void Interact()
        {
            // Debug.Log("Angel: ???");

            // Porneste afisarea dialogului asociat personajului.
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }    
}
