using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Pot : MonoBehaviour
{
    Dictionary<FoodType, int> iValues = null;
    List<IngredientType> ingredients = null;

    private void Start()
    {
        iValues = new Dictionary<FoodType, int>();
        foreach (FoodType type in Enum.GetValues(typeof(FoodType)))
        {
            iValues.Add(type, 0);
        }

        List<IngredientType> ingredients = new List<IngredientType>();
    }
    /*Types of food
     * Meat
     * Veg
     * Fruit
     * Dairy
     * ?
    */
    public class Recipe
    {
        
    }
    
    

    public void add(IngredientType it, FoodType ft, int value)
    {
        iValues[ft] += value;
        if (!ingredients.Contains(it))
        {
            ingredients.Add(it);
        }
    }
}
