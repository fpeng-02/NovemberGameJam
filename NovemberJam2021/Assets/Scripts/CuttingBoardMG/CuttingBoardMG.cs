using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuttingBoardMG : MinigameController
{
    [SerializeField] private Image progressBar;
    [SerializeField] private int requiredCuts;
    [SerializeField] private SpaceFlashedSprite chopper;  // get to the--!
    [SerializeField] private SpaceFlashedSprite spacebar;
    [SerializeField] private SpriteRenderer displaySR;
    private int cutsMade;
    private bool ended = false;  // prevent space spamming from trying to end the minigame many times
    private Ingredient ingredient;


    // Start is called before the first frame update
    void Start()
    {
        cutsMade = 0;
        progressBar.fillAmount = 0;
        foreach (Transform child in GameObject.Find("Player").transform) {
            if ((ingredient = child.gameObject.GetComponent<Ingredient>()) != null) {
                break;
            }
        }
        displaySR.sprite = ingredient.GetUnpreparedSprite();
    }

    // Update is called once per frame
    void Update()
    {
        if (ended) return;
        if (Input.GetKeyDown("space")) {
            StartCoroutine(chopper.Step());
            StartCoroutine(spacebar.Step());
            cutsMade++;
            progressBar.fillAmount = cutsMade * (1.0f / requiredCuts);
            if (cutsMade >= requiredCuts) {
                displaySR.sprite = ingredient.GetPreparedSprite();
                ingredient.ChangeToPreparedIngredient();

                EndMinigame("CuttingBoardMG");
                ended = true;
            }
        }
    }
}
