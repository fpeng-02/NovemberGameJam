using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] public IngredientType type;

    public void setIngredientType(IngredientType type)
    {
        this.type = type;
    }
    public IngredientType GetIngredientType() {
        return type;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot")
        {
            collision.gameObject.GetComponent<Pot>().add(1);
            Destroy(this.gameObject);
        }

    }
}
