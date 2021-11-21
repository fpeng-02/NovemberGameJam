using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CuttingBoardMG : MonoBehaviour
{
    [SerializeField] private Image progressBar;
    [SerializeField] private int requiredCuts;
    [SerializeField] private SpaceToggledSprite chopper;  // get to the--!
    [SerializeField] private SpaceToggledSprite spacebar;
    private int cutsMade;


    // Start is called before the first frame update
    void Start()
    {
        cutsMade = 0;
        progressBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /* 
         * continuously poll for space down.
         * when space down pressed, a series of things need to happen.
         * 1. top bar needs to fill up a bit more
         * 2. knife needs to come down 
         * 3. chop sound needs to play? 
         * 4. (opt) space bar needs to darken to indicate that yes you did press it or something
        */
        if (Input.GetKeyDown("space")) {
            StartCoroutine(chopper.Step());
            StartCoroutine(spacebar.Step());
            cutsMade++;
            progressBar.fillAmount = cutsMade * (1.0f / requiredCuts);
            if (cutsMade >= requiredCuts) {
                Debug.Log("CLEAR!");
                SceneManager.UnloadSceneAsync("CuttingBoardMG");
                Player.playingMinigame = false;
                // TODO: give the finished ingredient to the player
            }
        }
    }
}
