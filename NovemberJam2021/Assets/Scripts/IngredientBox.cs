using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : Interactable
{
    [SerializeField] public IngredientType type;
    [SerializeField] private GameObject ingredientGO;


    public override void OnInteract(Player player)  
    {
        if (player.GetIngredient() != null) {
            Debug.Log("Can only hold one ingredient at a time!");
        }
        else {
            Debug.Log("Ingredient box used!");
            player.SetIngredient(new Ingredient(type));
            
            GameObject IGO = Instantiate(ingredientGO, player.transform, true);
            IGO.transform.localPosition = new Vector3(0,1,0);
            player.setIngredientGO(IGO);
        }
    }
}
