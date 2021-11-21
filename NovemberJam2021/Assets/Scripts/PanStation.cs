using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanStation : Interactable
{
    public override void OnInteract(Player player)
    {
        if (player.GetIngredientGO() != null) {
            BeginMinigame("HeatMinigame");
            Player.playingMinigame = true;
        }
        else {
            Debug.Log("Player not holding an ingredient!");
        }
    }
}
