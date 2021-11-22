using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Interactable : MonoBehaviour
{
    private TransitionDoor transitionDoor;
    protected List<IngredientType> acceptedIngredients;

    public void Start()
    {
        transitionDoor = GameObject.Find("TransitionDoor").GetComponent<TransitionDoor>();
    }

    // not too sure if this is the best practice, but there's only one player anyway and the player should be the only thing "interacting"
    public abstract void OnInteract(Player player);

    public void AttemptMinigame(string sceneName, Player player)
    {
        if (player.GetIngredientGO() != null) {
            Ingredient ingredient = player.GetIngredientGO().GetComponent<Ingredient>();
            Debug.Log(ingredient.GetIngredientType());
            if (ingredient.GetPrepare() && acceptedIngredients.Contains(ingredient.GetIngredientType())) {
                Debug.Log(sceneName);
                BeginMinigame(sceneName);
                Player.playingMinigame = true;
            }
            else {
                Debug.Log("Player holding ingredient, but not able to be processed");
                //Sets the error text on
                player.transform.Find("ErrorText").gameObject.SetActive(true);
                StartCoroutine(wait(player));
            }
        }
        else {
            Debug.Log("Player not holding an ingredient!");
        }
    }

    public void BeginMinigame(string sceneName)
    {
        Debug.Log(transitionDoor);
        Debug.Log(sceneName);
        StartCoroutine(transitionDoor.TransitionThenLoadScene(sceneName));
    }

    //disable the error message after a certain amount of time
    public IEnumerator wait(Player player)
    {
        yield return new WaitForSeconds(1.0f);
        player.transform.Find("ErrorText").gameObject.SetActive(false);
    }
}
