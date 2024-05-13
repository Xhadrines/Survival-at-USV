using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public class Cat : MonoBehaviour, Interactable
    {
        // Dialogul asociat personajului.
        [SerializeField] Dialog dialog;

        // Metoda pentru a interactiona cu jucatorul.
        public void Interact()
        {
            // Debug.Log("Cat: Frrrr");

            // Porneste afisarea dialogului asociat personajului.
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }    
}
