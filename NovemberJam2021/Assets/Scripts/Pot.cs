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
        requiredType.Add(FoodType.Vegetable, 3);
        recipeList.Add(new Recipe(requiredType, IngredientType.Carrot, "Ratatouille"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 3);
        recipeList.Add(new Recipe(requiredType, IngredientType.Lettuce, "Fancy Salad"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Salad"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 2);
        requiredType.Add(FoodType.Flour, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.Tomato, "Spaghetti"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 2);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.Meat, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.Tomato, "Spaghetti and Meatballs"));


        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Rice, 1);
        requiredType.Add(FoodType.Egg, 1);

        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Egg Fried Rice"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Rice, 1);
        requiredType.Add(FoodType.Meat, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.Rice, "Shrimp Fried Rice"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Meat, 2);
        requiredType.Add(FoodType.Flour, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Meaty Sandwich"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Meat, 1);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.SoupStock, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Ramen"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Meat, 1);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.SoupStock, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.Carrot, "Chicken Noodle Soup"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Meat, 4);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Meatballs"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.SoupStock, 1);
        requiredType.Add(FoodType.Dairy, 1);
        requiredType.Add(FoodType.Meat, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Clam Chowder"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.SoupStock, 1);
        requiredType.Add(FoodType.Dairy, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Chowder"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Egg, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Fried Egg"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Meat, 1);
        requiredType.Add(FoodType.Egg, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Green Eggs and Ham"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Egg, 2);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Omelette"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Dairy, 1);
        requiredType.Add(FoodType.Egg, 2);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Omelete du Fromage"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Flour, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.Carrot, "Carrot Bread"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Flour, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Bread"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Flour, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Bread"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Rice, 1);
        requiredType.Add(FoodType.Meat, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Sushi"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.Meat, 1);
        requiredType.Add(FoodType.Dairy, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.Lettuce, "Lettuce Wrapped Burger"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.Meat, 1);
        requiredType.Add(FoodType.Dairy, 1);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Burger"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.Meat, 2);
        requiredType.Add(FoodType.Dairy, 2);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Double Double"));

        requiredType = new Dictionary<FoodType, int>();
        requiredType.Add(FoodType.Vegetable, 1);
        requiredType.Add(FoodType.Flour, 1);
        requiredType.Add(FoodType.Meat, 2);
        requiredType.Add(FoodType.Dairy, 2);
        recipeList.Add(new Recipe(requiredType, IngredientType.None, "Double Double"));

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
        
        //Debug.Log(topRecipe.name);
        return topRecipe;
    }

    public override void OnInteract(Player player)
    {
        Transform potIndicator = GameObject.Find("PotIndicator").transform;
        foreach (Transform child in potIndicator) {
            if (child.gameObject.tag != "PotIndicatorWall")
                GameObject.Destroy(child.gameObject);
        }

        Recipe returnRecipe = FindRecipes();
        int recipePoints;
        string recipeNameToPass;
        if (returnRecipe == null)
        {
            recipeNameToPass = "wet goop...";
            recipePoints = 0;
        }
        else
        {
            //number of points for recipe
            recipeNameToPass = returnRecipe.name;
            recipePoints = returnRecipe.recipeValue + skillPoint;
        }

        // Draw in the transition board
        TransitionDoor transitionDoor = GameObject.Find("TransitionDoor").GetComponent<TransitionDoor>();
        transitionDoor.SetCreatedFoodText(recipeNameToPass, recipePoints);
        StartCoroutine(transitionDoor.TransitionToCreatedFood());

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
