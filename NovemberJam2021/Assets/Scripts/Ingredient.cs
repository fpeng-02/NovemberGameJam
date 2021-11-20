using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient
{
    private IngredientType type;
    public IngredientType GetIngredientType() { return type; }
    public Ingredient(IngredientType type) { this.type = type; }
}
