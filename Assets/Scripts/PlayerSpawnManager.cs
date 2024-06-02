using UnityEngine;

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
