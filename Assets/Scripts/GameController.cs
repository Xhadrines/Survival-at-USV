using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SurvivalAtUSV
{
    public enum GameState
    {
        FreeMove, Dialog, Battle
    }

    public class GameController : MonoBehaviour
    {
        [SerializeField] PlayerController playerController;

        GameState state;

        private void Start()
        {
            DialogManager.Instance.OnShowDialog += () =>
            {
                state = GameState.Dialog;
            };

            DialogManager.Instance.OnHideDialog += () =>
            {
                if (state == GameState.Dialog)
                    state = GameState.FreeMove;
            };
        }

        private void Update()
        {
            if (state == GameState.FreeMove)
                playerController.HandleUpdate();
            
            else if (state == GameState.Dialog)
                DialogManager.Instance.HandleUpdate();

            else if (state == GameState.Battle)
                playerController.HandleUpdate();
        }
    }
}