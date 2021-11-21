using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;


public class Pot : Interactable
{

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
        public String name;
        public Recipe(Dictionary<FoodType, int> requiredType, IngredientType requiredIngredient, String name)
        {
            this.requiredType = requiredType;
            this.requiredIngredient = requiredIngredient;
            this.name = name;
            foreach (int item in requiredType.Values)
            {
                recipeValue += item;
            }
        }
    }

    Dictionary<FoodType, int> iValues = null;
    List<IngredientType> ingredients = null;
    List<Recipe> recipeList = null;
    int skillPoint;
    ScoreController scoreController;


    private void Start()
    {
        iValues = new Dictionary<FoodType, int>();
        foreach (FoodType type in Enum.GetValues(typeof(FoodType)))
        {
            iValues.Add(type, 0);
        }
        ingredients = new List<IngredientType>();
        skillPoint = 0;

        //define list of recipes. hard code
        recipeList = new List<Recipe>();

        Dictionary<FoodType, int> requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 2);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Lettuce2"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Lettuce1"));
        //recipeList.Add();

        scoreController = GameObject.Find("ScoreBoard").GetComponent<ScoreController>();

    }


    public void AddFood(IngredientType it, FoodType ft, int value, int skillPoint)
    {
        iValues[ft] += value;
        Debug.Log(ingredients);
        if (!ingredients.Contains(it))
        {
            ingredients.Add(it);
        }
        this.skillPoint += skillPoint;
    }

    public Recipe FindRecipes(){
        Recipe topRecipe = null;
        int topRecipeAmount = 0;
       

        foreach (Recipe curRecipe in recipeList)
        {
            //Debug.Log(curRecipe.name);
            bool validIngredientAmount = true;
            foreach (KeyValuePair<FoodType, int> recipeRequirement in curRecipe.requiredType)
            {
                //Debug.Log(iValues[FoodType.Vegetable] + " and " + recipeRequirement.Value);
                if (iValues[recipeRequirement.Key] < recipeRequirement.Value)
                {
                    validIngredientAmount = false;
                }
            }
            if ((ingredients.Contains(curRecipe.requiredIngredient) || curRecipe.requiredIngredient == IngredientType.None)&& validIngredientAmount)
            {
                if (curRecipe.recipeValue > topRecipeAmount) {
                    topRecipe = curRecipe;
                    topRecipeAmount = curRecipe.recipeValue;
                }
            }
        }
        Debug.Log(topRecipe.name);
        return topRecipe;
    }

    public override void OnInteract(Player player)
    {
        Recipe returnRecipe = FindRecipes();
        int recipePoints = returnRecipe.recipeValue + skillPoint;
        scoreController.updateText(recipePoints);
        
        //Reset iValues/ingredients
        iValues = new Dictionary<FoodType, int>();
        foreach (FoodType type in Enum.GetValues(typeof(FoodType)))
        {
            iValues.Add(type, 0);
        }

        ingredients = new List<IngredientType>();
        skillPoint = 0;
        //window popup and sprite?
    }
    
}
