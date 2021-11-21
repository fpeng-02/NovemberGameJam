using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    [SerializeField] private IngredientType type;
    [SerializeField] private FoodType fType;
    [SerializeField] private int value;
    [SerializeField] private int skillPoint;
    [SerializeField] private Sprite unpreparedSprite;
    [SerializeField] private Sprite preparedSprite;
    private SpriteRenderer sr;
    private bool canPrepare;

    [SerializeField] private GameObject dummyFloatingObject;

    private void Start()
    {
        skillPoint = 0;
        canPrepare = true;
        sr = GetComponent<SpriteRenderer>();
        unpreparedSprite = sr.sprite;
    }

    public void ChangeToPreparedIngredient() 
    {
        skillPoint = 1;
        sr.sprite = preparedSprite;
        canPrepare = false;
    }

    public Sprite GetUnpreparedSprite() { return unpreparedSprite; }
    public Sprite GetPreparedSprite() { return preparedSprite; }

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
            // spawn a random thing inside 
            GameObject go = Instantiate(dummyFloatingObject);
            go.GetComponent<FloatingIngredient>().SetSprite(canPrepare ? unpreparedSprite : preparedSprite);

            collision.gameObject.GetComponent<Pot>().AddFood(type,fType, value, skillPoint);
            Destroy(this.gameObject);
        }

    }
    
}
