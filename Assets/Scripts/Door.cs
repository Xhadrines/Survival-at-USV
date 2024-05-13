using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public class Door : MonoBehaviour, Interactable
    {
        // Dialogul asociat personajului.
        [SerializeField] Dialog dialog;

        // Metoda pentru a interactiona cu jucatorul.
        public void Interact()
        {
            // Debug.Log("Door: Lock");

            // Porneste afisarea dialogului asociat personajului.
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }    
}
