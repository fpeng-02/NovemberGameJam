using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throwable : MonoBehaviour
{
    [SerializeField] public IngredientType type;

    public void setIngredientType(IngredientType type)
    {
        this.type = type;
    }
    public IngredientType GetIngredientType() {
        return type;
    }
}
