using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FluctuatingBar : MonoBehaviour
{
    private Image bar;
    private float heatLevel;
    [SerializeField] private float volatility;

    public float GetHeatLevel() { return heatLevel; }

    // Start is called before the first frame update
    void Start()
    {
        bar = GetComponent<Image>();
        heatLevel = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("space")) {
            heatLevel += volatility;
        }
        else {
            heatLevel -= volatility;
        }
        heatLevel = Mathf.Min(1, heatLevel);
        heatLevel = Mathf.Max(0, heatLevel);
        bar.fillAmount = heatLevel;
    }
}
