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
    private int cutsMade;
    private bool ended = false;  // prevent space spamming from trying to end the minigame many times

    new void Start()
    {
        base.Start();
        cutsMade = 0;
        progressBar.fillAmount = 0;
    }

    void Update()
    {
        if (ended) return;
        if (Input.GetKeyDown("space")) {
            StartCoroutine(chopper.Step());
            StartCoroutine(spacebar.Step());
            cutsMade++;
            progressBar.fillAmount = cutsMade * (1.0f / requiredCuts);
            if (cutsMade >= requiredCuts) {
                EndMinigame("CuttingBoardMG");
                ended = true;
            }
        }
    }
}
