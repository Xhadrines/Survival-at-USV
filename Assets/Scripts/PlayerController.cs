// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using System.Collections;
using UnityEngine;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    // O clasa pentru controlul jucatorului in joc.
    public class PlayerController : MonoBehaviour
    {
        // Viteza de deplasare a jucatorului.
        public float moveSpeed;

        // Variabila pentru a verifica daca jucatorul se deplaseaza.
        private bool isMoving;

        // Vectorul de intrare pentru miscare.
        private Vector2 input;

        // Animatorul atasat jucatorului.
        private Animator animator;

        // Stratul de obiecte solide.
        public LayerMask solidObjectsLayer;

        // Stratul de obiecte cu care poate interactiona.
        public LayerMask interactableLayer;

        // Metoda apelata la initializarea obiectului.
        private void Awake() 
        {
            // Initializarea animatorului.
            animator = GetComponent<Animator>();
        }

        // Metoda pentru a trata input-ul utilizatorului.
        public void HandleUpdate()
        {
            // Verificam daca jucatorul nu este deja in miscare.
            if (!isMoving)
            {
                // Citim input-ul utilizatorului pe axe.
                input.x = Input.GetAxisRaw("Horizontal");
                input.y = Input.GetAxisRaw("Vertical");

                // Debug.Log("This is input.x: " + input.x);
                // Debug.Log("This is input.y: " + input.y);

                // Daca jucatorul se misca pe axa X, blocam miscarea pe axa Y.
                if (input.x != 0)
                    input.y = 0;

                // Daca exista un input de la utilizator, actualizam animatia si miscarea jucatorului.
                if (input != Vector2.zero)
                {
                    animator.SetFloat("moveX", input.x);
                    animator.SetFloat("moveY", input.y);

                    // Calculam pozitia tinta.
                    var targetPosition = transform.position;
                    targetPosition.x += input.x;
                    targetPosition.y += input.y;

                    // Verificam daca pozitia este accesibila si miscam jucatorul.
                    if (IsWalkable(targetPosition))
                        StartCoroutine(Move(targetPosition));
                }
            }
            // Actualizam parametrul "isMoving" al animatorului.
            animator.SetBool("isMoving", isMoving);

            // Daca este apasata tasta Space, jucatorul interactioneaza.
            if (Input.GetKeyDown(KeyCode.Space))
                Interact();
        }

        // Metoda pentru interactiune.
        void Interact()
        {
            // Determinam directia in care se uita jucatorul si pozitia pentru interactiune.
            var facingDirection = new Vector3(animator.GetFloat("moveX"), animator.GetFloat("moveY"));
            var interactPosition = transform.position + facingDirection;

            // Debug.DrawLine(transform.position, interactPosition, Color.red, 1f);

            // Detectam daca exista obiecte cu care poate interactiona in pozitia determinata.
            var collider = Physics2D.OverlapCircle(interactPosition, 0.2f, interactableLayer);

            // Daca exista un obiect cu care poate interactiona, il interactioneaza.
            if (collider != null)
                collider.GetComponent<Interactable>()?.Interact();
        }

        // Metoda pentru miscare in timp real.
        IEnumerator Move(Vector3 targetPosition)
        {
            // Jucatorul este in miscare.
            isMoving = true;

            // Cat timp jucatorul nu a ajuns la destinatie, il miscam in directia destinatiei.
            while (Vector3.Distance(transform.position, targetPosition) > 0.01f)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

                yield return null;
            }

            // Jucatorul a ajuns la destinatie.
            transform.position = targetPosition;
            
            // Jucatorul nu mai este in miscare.
            isMoving = false;
        }

        // Metoda pentru a verifica daca o pozitie este accesibila.
        private bool IsWalkable(Vector3 targetPosition)
        {
            // Verificam daca exista coliziuni la pozitia tinta.
            if (Physics2D.OverlapCircle(targetPosition, 0.2f, solidObjectsLayer | interactableLayer) != null)
                return false;
                
            return true;
        }
    }
}
