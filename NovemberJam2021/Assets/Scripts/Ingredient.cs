using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] public IngredientType type;
    [SerializeField] public int value;
    public bool canPrepare;


    private void Start()
    {
        canPrepare = true;
    }

    public void setIngredientType(IngredientType type)
    {
        this.type = type;
    }
    public IngredientType GetIngredientType() {
        return type;
    }
    public void setPrepare(bool canPrepare)
    {
        this.canPrepare = canPrepare;
    }
    public bool getPrepare()
    {
        return canPrepare;
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
