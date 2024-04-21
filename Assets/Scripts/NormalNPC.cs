using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public class NPC : MonoBehaviour, Interactable
    {
        [SerializeField] Dialog dialog;

        public void Interact()
        {
            // Debug.Log("NPC: Don't hit me, I'll do whatever you want!");

            StartCoroutine(DialogManager.Instance.ShowDialog(dialog));
        }
    }
}
