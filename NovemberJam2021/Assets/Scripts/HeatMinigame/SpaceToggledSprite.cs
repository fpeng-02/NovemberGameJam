using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceToggledSprite : MonoBehaviour
{
    private SpriteRenderer sr;
    [SerializeField] private Sprite upSprite;
    [SerializeField] private Sprite downSprite;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = upSprite;
    }

    void Update()
    {
        sr.sprite = Input.GetKey("space") ? downSprite : upSprite;
    }
}
