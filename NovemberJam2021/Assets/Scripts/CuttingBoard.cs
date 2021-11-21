using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuttingBoard : Interactable
{
    public override void OnInteract(Player player)
    {
        if (player.GetIngredientGO() != null) {
            Debug.Log("Start chopping minigame...");
            SceneManager.LoadScene("CuttingBoardMG", LoadSceneMode.Additive);
            
            // don't set holding ingredient to false bc chopping will make another ingredient? 
            // also, should we test the type of ingredient the player is holding?
            // if the player has a chopped thing, idk if it's a great idea to let them chop it again.. (unless we want like. diced or minced or something but that sounds complicated)
        }
        else {
            Debug.Log("Player not holding an ingredient!");
        }
    }
}
