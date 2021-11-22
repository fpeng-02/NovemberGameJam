using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CuttingBoard : Interactable
{
    new void Start()
    {
        base.Start();
        acceptedIngredients = new List<IngredientType>();
        acceptedIngredients.Add(IngredientType.Lettuce);
        acceptedIngredients.Add(IngredientType.Tomato);
        acceptedIngredients.Add(IngredientType.Carrot);
    }

    public override void OnInteract(Player player)
    {
        AttemptMinigame("CuttingBoardMG", player);
    }
}
