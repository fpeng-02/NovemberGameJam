using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KnifeChop : MonoBehaviour
{
    private SpriteRenderer knifeSR;
    [SerializeField] private Sprite knifeUpSprite;
    [SerializeField] private Sprite knifeDownSprite;

    // Start is called before the first frame update
    void Start()
    {
        knifeSR = GetComponent<SpriteRenderer>();
        knifeSR.sprite = knifeUpSprite;
    }

    public IEnumerator Chop()
    {
        knifeSR.sprite = knifeDownSprite;
        yield return new WaitForSeconds(0.1f);
        knifeSR.sprite = knifeUpSprite;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
