using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Pot : MonoBehaviour
{
    Dictionary<FoodType, int> iValues = null;
    List<IngredientType> ingredients = null;

    List<Recipe> recipeList = null;
    private void Start()
    {
        iValues = new Dictionary<FoodType, int>();
        foreach (FoodType type in Enum.GetValues(typeof(FoodType)))
        {
            iValues.Add(type, 0);
        }

        List<IngredientType> ingredients = new List<IngredientType>();

        //define list of recipes. hard code
        recipeList = new List<Recipe>();
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
        public Dictionary<FoodType, int> requiredType;
        public IngredientType requiredIngredient;
        public int recipeValue = 0;
        public Recipe(Dictionary<FoodType, int> requiredType, IngredientType requiredIngredient)
        {
            this.requiredType = requiredType;
            this.requiredIngredient = requiredIngredient;
            foreach (int item in requiredType.Values)
            {
                recipeValue += item;
            }
        }
    }
    


    public void add(IngredientType it, FoodType ft, int value)
    {
        iValues[ft] += value;
        if (!ingredients.Contains(it))
        {
            ingredients.Add(it);
        }
    }

    public Recipe findRecipes(){
        Recipe topRecipe = null;
        int topRecipeAmount = 0;
       

        foreach (Recipe curRecipe in recipeList)
        {
            bool validIngredientAmount = true;
            foreach (KeyValuePair<FoodType, int> recipeRequirement in curRecipe.requiredType)
            {
                if (!(iValues[recipeRequirement.Key] > recipeRequirement.Value))
                {
                    validIngredientAmount = false;
                }
            }
            if (ingredients.Contains(curRecipe.requiredIngredient) && validIngredientAmount)
            {
                if (curRecipe.recipeValue > topRecipeAmount) {
                    topRecipe = curRecipe;
                    topRecipeAmount = curRecipe.recipeValue;
                }
            }
        }
        return topRecipe;
    }
}
