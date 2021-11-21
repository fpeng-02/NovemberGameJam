using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] public IngredientType type;
    [SerializeField] public FoodType fType;
    [SerializeField] public int value;
    public bool canPrepare;


    private void Start()
    {
        canPrepare = true;
    }

    public void SetIngredientType(IngredientType type) { this.type = type; }
    public IngredientType GetIngredientType() {return type;}

    public void SetPrepare(bool canPrepare) { this.canPrepare = canPrepare; }
    public bool SetPrepare() { return canPrepare; }

    public void SetValue(int value) { this.value = value; }
    public int GetValue() { return value; }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Pot")
        {
            collision.gameObject.GetComponent<Pot>().add(type,fType, value);
            Destroy(this.gameObject);
        }

    }
    
}
