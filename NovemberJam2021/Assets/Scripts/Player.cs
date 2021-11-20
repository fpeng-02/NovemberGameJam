using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed = 4;
    private float h;
    private float v;
    private Vector3 dirVect;
    private Rigidbody2D rb;
    private bool throwing;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        throwing = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If not throwing food, catch movement inputs or request to throw
        // If throwing, catch release of right click (or maybe also catch a key to cancel throw?) 
        if (throwing) {
            if (Input.GetMouseButtonUp(1)) {
                throwing = false;
                Debug.Log("Finished throw");
            }
        } else {
            if (Input.GetMouseButtonDown(1)) {
                throwing = true;
                Debug.Log("Throwing food...");
            }
        }

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");

        // if throwing, don't let the player move
        if (throwing) {
            dirVect = Vector3.zero;
        }
        else {
            dirVect = (new Vector3(h, v, 0)).normalized;
        }
            
    }
    public void FixedUpdate()
    {
        rb.MovePosition(rb.transform.position + dirVect * baseMoveSpeed * Time.deltaTime);
    }
}
