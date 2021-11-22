using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameTimer : MonoBehaviour
{
    [SerializeField] private float totalTime;
    [SerializeField] private GameObject timer;
    private bool frozen; 

    // Start is called before the first frame update
    void Start()
    {
        frozen = true;
        var timerTMP = timer.GetComponent<TextMeshProUGUI>();
        timerTMP.SetText($"{Mathf.Max(0, Mathf.Floor(totalTime))}");
    }
     
    // wait for player to finish minigame
    IEnumerator EndGame (Player player) {
        while (player.GetPlayingMinigame()) yield return null;
        TransitionDoor tdoor = GameObject.Find("TransitionDoor").GetComponent<TransitionDoor>();
        StartCoroutine(tdoor.TransitionToGameOver());
    }

    public void Unfreeze() { frozen = false; }

    // Update is called once per frame
    void Update()
    {
        if (frozen) return;
        totalTime -= Time.deltaTime;
        var timerTMP = timer.GetComponent<TextMeshProUGUI>();
        timerTMP.SetText($"{Mathf.Max(0, Mathf.Floor(totalTime))}");
        if (totalTime <= 0) {
            Player player = GameObject.Find("Player").GetComponent<Player>();
            StartCoroutine(EndGame(player));
        }
    }
}
