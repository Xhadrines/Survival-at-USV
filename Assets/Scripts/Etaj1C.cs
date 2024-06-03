// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using UnityEngine;
using UnityEngine.SceneManagement;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    public class Etaj1C : MonoBehaviour, Interactable
    {
        // Metoda pentru a interactiona cu jucatorul.
        public void Interact()
        {
            // Schimbare scena
            SceneManager.LoadScene(3);
        }
    }
}
