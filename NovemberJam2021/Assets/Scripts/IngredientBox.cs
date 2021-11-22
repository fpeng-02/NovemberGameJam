using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IngredientBox : Interactable
{
    [SerializeField] private GameObject ingredientGO;
    AudioController audioController;

    void Start()
    {
        audioController = GameObject.Find("Audio").GetComponent<AudioController>();
        gameObject.transform.Find("IngredientDisplay").GetComponent<SpriteRenderer>().sprite = ingredientGO.GetComponent<Ingredient>().GetUnpreparedSprite();
    }

    public override void OnInteract(Player player)  
    {
        if (player.GetIngredientGO() != null) {
            Debug.Log("Can only hold one ingredient at a time!");
        }
        else {
            Debug.Log("Ingredient box used!");
            audioController.playAudio("barrel");
            GameObject IGO = Instantiate(ingredientGO, player.transform, true);
            IGO.transform.localPosition = new Vector3(0,1,0);
            player.setIngredientGO(IGO);
        }
    }
}
