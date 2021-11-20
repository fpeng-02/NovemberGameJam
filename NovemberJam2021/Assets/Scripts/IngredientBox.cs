using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : Interactable
{
    public override void OnInteract(Player player)  
    {
        if (player.GetHoldingIngredient()) {
            Debug.Log("Can only hold one ingredient at a time!");
        }
        else {
            Debug.Log("Ingredient box used!");
            player.SetHoldingIngredient(true);
        }
    }
}
