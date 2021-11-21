using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HeatMG : MinigameController
{
    private float progress;
    [SerializeField] private float progressRate;
    [SerializeField] private float tolerance; 
    [SerializeField] private FluctuatingBar heatBar;
    [SerializeField] private Image progressBar;
    private bool ended = false;

    // Start is called before the first frame update
    void Start()
    {
        progressBar.fillAmount = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (ended) return;

        if (progress >= 1) {
            ended = true;
            EndMinigame("HeatMinigame");
        }

        // let's just make it so they keep the heat an interval from the center
        float testHeatLevel = heatBar.GetHeatLevel();
        if (testHeatLevel < 0.5f + tolerance && testHeatLevel > 0.5f - tolerance) {
            progress += progressRate;
        }
        progressBar.fillAmount = progress;
    }
}
