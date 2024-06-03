// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using UnityEngine;
using UnityEngine.SceneManagement;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    public class SceneController : MonoBehaviour
    {
        public static SceneController instance;

        private void Awake() 
        {
            if (instance == null)
            {
                instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void NextLevel()
        {
            SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void LoadScene(string sceneName) 
        {
            SceneManager.LoadSceneAsync(sceneName);
        }
    }
}
