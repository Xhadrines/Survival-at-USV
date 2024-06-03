// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using UnityEngine;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    public class InteractObjects : MonoBehaviour, Interactable
    {
        // Dialogul asociat personajului.
        [SerializeField] Dialog dialog;

        // Metoda pentru a interactiona cu jucatorul.
        public void Interact()
        {
            // Debug.Log("USV: University "Stefan cel mare" of Suceava");

            // Porneste afisarea dialogului asociat personajului.
            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }    
}
