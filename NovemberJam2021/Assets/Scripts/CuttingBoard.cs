using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuttingBoard : Interactable
{
    public override void OnInteract(Player player)
    {
        AttemptMinigame("CuttingBoardMG", player);
    }
}
