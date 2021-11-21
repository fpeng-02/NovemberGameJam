using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanStation : Interactable
{
    public override void OnInteract(Player player)
    {
        AttemptMinigame("HeatMinigame", player);
    }
}
