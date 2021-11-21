using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreController : MonoBehaviour
{
    int totalScore = 0;
    // Start is called before the first frame update
    public void updateText(int score){
        totalScore += score;
        var damageTextTMP = GetComponentInChildren<TextMeshProUGUI>();
        damageTextTMP.color = Color.red;
        damageTextTMP.SetText("Score: " + totalScore);
    }
}
