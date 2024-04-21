// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using UnityEngine;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    // Enumeratie pentru diferitele stari ale jocului.
    public enum GameState
    {
        FreeMove, Dialog, Battle
    }

    // Clasa pentru controlul general al jocului.
    public class GameController : MonoBehaviour
    {
        // Referinta catre controller-ul jucatorului.
        [SerializeField] PlayerController playerController;

        // Starea actuala a jocului.
        GameState state;

        // Metoda apelata la pornirea jocului.
        private void Start()
        {
            // Abonare la evenimentul de afisare a dialogului.
            DialogManager.Instance.OnShowDialog += () =>
            {
                state = GameState.Dialog;
            };

            // Abonare la evenimentul de ascundere a dialogului.
            DialogManager.Instance.OnHideDialog += () =>
            {
                // Daca jocul era in starea de dialog, il intoarcem la starea de deplasare libera.
                if (state == GameState.Dialog)
                    state = GameState.FreeMove;
            };
        }

        // Metoda apelata la fiecare frame.
        private void Update()
        {
            // Verificam starea jocului si apelam metodele corespunzatoare.
            if (state == GameState.FreeMove)
                playerController.HandleUpdate();
            
            else if (state == GameState.Dialog)
                DialogManager.Instance.HandleUpdate();

            else if (state == GameState.Battle)
                playerController.HandleUpdate();
        }
    }
}
