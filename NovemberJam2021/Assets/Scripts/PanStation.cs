using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PanStation : Interactable
{
    new void Start()
    {
        base.Start();
        acceptedIngredients = new List<IngredientType>();
        acceptedIngredients.Add(IngredientType.Meat);
        acceptedIngredients.Add(IngredientType.Egg);
    }

    public override void OnInteract(Player player)
    {
        AttemptMinigame("HeatMinigame", player);
    }
}
