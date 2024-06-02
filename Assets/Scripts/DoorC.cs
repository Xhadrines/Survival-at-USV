using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public class DoorC : MonoBehaviour, Interactable
    {
        // Metoda pentru a interactiona cu jucatorul.
        public void Interact()
        {
            SceneController.instance.NextLevel();
        }
    }
}