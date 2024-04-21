using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public class RivalNPC : MonoBehaviour, Interactable
    {
        [SerializeField] Dialog dialog;

        public void Interact()
        {
            // Debug.Log("NPC: I'm better than you!");

            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }
}
