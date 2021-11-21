using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceFlashedSprite : MonoBehaviour
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

    public IEnumerator Step()
    {
        sr.sprite = downSprite;
        yield return new WaitForSeconds(0.1f);
        sr.sprite = upSprite;
    }
}
