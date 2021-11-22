using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloatingIngredient : MonoBehaviour
{
    [SerializeField] private float xrange;
    [SerializeField] private float yrange;
    private Transform potIndicator;
    private Rigidbody2D rb2d;
    private SpriteRenderer sr;
    private float velocityThreshold = 1f;

    // Start is called before the first frame update
    void Start()
    {
        potIndicator = GameObject.Find("PotIndicator").transform;
        sr = GetComponent<SpriteRenderer>();
        rb2d = GetComponent<Rigidbody2D>();
        transform.parent = potIndicator;

        Vector3 center = potIndicator.position;
        Vector3 offset = new Vector3(Random.Range(-xrange, xrange), Random.Range(-yrange, yrange));
        Vector3 spawnLoc = center + offset;
        spawnLoc.z = -1;
        this.transform.position = spawnLoc;
    }

    public void SetSprite(Sprite sprite) { StartCoroutine(WaitForSR(sprite)); }

    // sprite of the floating object needs to be set by the Ingredient that instantiates it, but we might try to set a sprite before GetComponent<SpriteRenderer> finishes
    IEnumerator WaitForSR(Sprite sprite)
    {
        while (sr == null) yield return null;
        sr.sprite = sprite;
    }

    // Update is called once per frame
    void Update()
    {
        // if velocity is too low, choose a random direction to fling in.
        if (rb2d.velocity.magnitude < velocityThreshold) {
            float xForce = Random.Range(-1.0f, 1.0f);
            float yForce = Random.Range(-1.0f, 1.0f);
            Vector2 force = new Vector2(xForce, yForce);
            force = force.normalized;
            rb2d.AddForce(force);
        }
    }
}
