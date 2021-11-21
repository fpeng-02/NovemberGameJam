using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Strober : MonoBehaviour
{
    [SerializeField] private float cycleLength;
    [SerializeField] private Interactable intable;
    private SpriteRenderer sr;
    private float cycleOffset;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.color = new Color(1, 1, 1, 0);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.transform.gameObject.tag != "Player") return;
        sr.color = new Color(1, 1, 1 ,0);
        cycleOffset = Time.time;
    }

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.transform.gameObject.tag != "Player") return;
        sr.color = Color.Lerp(new Color(1, 1, 1, 0), new Color(1, 1, 1, 0.5f), Mathf.PingPong(Time.time - cycleOffset, cycleLength));
    }

    void OnTriggerExit2D(Collider2D col)
    {
        if (col.transform.gameObject.tag != "Player") return;
        Debug.Log("EXIT");
        sr.color = new Color(1, 1, 1, 0);
    }
}
