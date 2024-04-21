// Instructiunea using pentru a importa namespace-urile necesare din biblioteca standard si alte pachete.
using UnityEngine;

// Spatiul de nume pentru a organiza si grupa clasele si alte entitati legate de jocul "Survival at USV".
namespace SurvivalAtUSV
{
    public class AudioManager : MonoBehaviour
    {
        // Declarare pentru obiectul AudioSource care va reda muzica.
        [Header(">--------------------<Audio Source>--------------------<")]
        [SerializeField] AudioSource musicSource;

        // Declarare pentru clipul audio care va fi redat.
        [Header(">--------------------<Audio Clip>--------------------<")]
        public AudioClip background;

        // Declarare pentru volumul muzicii, cu un slider disponibil între 0 și 1 în editorul Unity.
        [Header(">--------------------<Audio Volume>--------------------<")]
        [Range(0f, 1f)]
        public float musicVolume = 1f;

        // Metoda care se execută la pornirea obiectului.
        private void Start()
        {
            // Se atribuie clipul de fundal obiectului AudioSource.
            musicSource.clip = background;

            // Seteaza redarea in bucla.
            musicSource.loop = true;

            // Se pornește redarea muzicii.
            musicSource.Play();

            // Setează volumul muzicii la începutul jocului conform valorii specificate.
            musicSource.volume = musicVolume;
        }

        // Metodă pentru a actualiza volumul muzicii din alte componente sau scripturi.
        public void SetMusicVolume(float volume)
        {
            // Se actualizează variabila musicVolume cu noua valoare.
            musicVolume = volume;
            
            // Se actualizează volumul muzicii.
            musicSource.volume = volume;
        }
    }
}
