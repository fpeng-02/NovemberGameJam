using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private IngredientType type;
    [SerializeField] private FoodType fType;
    [SerializeField] private int value;
    [SerializeField] private int skillPoint;

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
            collision.gameObject.GetComponent<Pot>().AddFood(type,fType, value, skillPoint);
            Destroy(this.gameObject);
        }

    }
    
}
