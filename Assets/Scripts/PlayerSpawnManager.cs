// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using UnityEngine;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    public class PlayerSpawnManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            // Găsește punctul de spawn
            GameObject spawnPoint = GameObject.Find("SpawnPoint");

            // Găsește jucătorul
            GameObject player = GameObject.FindGameObjectWithTag("Player");

            // Plasează jucătorul la punctul de spawn
            if (spawnPoint != null && player != null)
            {
                player.transform.position = spawnPoint.transform.position;
                player.transform.rotation = spawnPoint.transform.rotation;
            }
        }
    }
}
