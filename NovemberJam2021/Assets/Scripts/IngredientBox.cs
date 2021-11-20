using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : Interactable
{
    [SerializeField] public IngredientType type;
    public override void OnInteract(Player player)  
    {
        if (player.GetIngredient() != null) {
            Debug.Log("Can only hold one ingredient at a time!");
        }
        else {
            Debug.Log("Ingredient box used!");
            player.SetIngredient(new Ingredient(type));
        }
    }
}
