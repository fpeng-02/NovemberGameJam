using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinigameController : MonoBehaviour
{
    [SerializeField] private SpriteRenderer displaySR;
    protected Ingredient ingredient;
    public void Start()
    {
        foreach (Transform child in GameObject.Find("Player").transform) {
            if ((ingredient = child.gameObject.GetComponent<Ingredient>()) != null) {
                break;
            }
        }
        displaySR.sprite = ingredient.GetUnpreparedSprite();
    }

    public void EndMinigame(string sceneName)
    {
        displaySR.sprite = ingredient.GetPreparedSprite();
        ingredient.ChangeToPreparedIngredient();
        TransitionDoor transitionDoor = GameObject.Find("TransitionDoor").GetComponent<TransitionDoor>();
        transitionDoor.unloadProxy(sceneName); // have to call a *function* and not start coroutine because this GO gets destroyed
    }
}
