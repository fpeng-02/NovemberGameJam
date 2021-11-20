using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float reach;    // how far the player has to be from an interactable object to access it, i.e. distance of raycast
    [SerializeField] private float maxThrowPower;
    private float h;
    private float v;
    private Vector3 dirVect;
    private Rigidbody2D rb;
    private bool throwing;
    private float throwPower;
    private Ingredient ingredient = null;

    public void SetIngredient(Ingredient ing) { ingredient = ing; }
    public Ingredient GetIngredient() { return ingredient; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        throwing = false;
        ingredient = null;
    }

    // Update is called once per frame
    void Update() {
        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        dirVect = (new Vector3(h, v, 0)).normalized;

        // if throwing, don't let the player move
        if (throwing) {
            dirVect = Vector3.zero;
            if (Input.GetMouseButtonUp(1)) {
                throwPower = Mathf.Min(maxThrowPower, Time.time - throwPower);
                throwing = false;
                ingredient = null;
                Debug.Log($"Food thrown with {throwPower} force!");
            }
        }
        else {
            if (Input.GetMouseButtonDown(1)) {
                if (ingredient != null) {
                    throwing = true;
                    Debug.Log("Throwing food...");
                    dirVect = Vector3.zero;
                    throwPower = Time.time;
                }
            }

            if (Input.GetButtonDown("Interact")) {
                // Raycast for interactable things 
                LayerMask mask = LayerMask.GetMask("Interactable");
                RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up, reach, mask);
                if (hit.collider != null) {
                    // should be guaranteed an Interactable here, so no nulls
                    hit.transform.gameObject.GetComponent<Interactable>().OnInteract(this);
                }
            }
        }
    }
    public void FixedUpdate()
    {
        if (dirVect.magnitude > 0) transform.rotation = Quaternion.FromToRotation(Vector2.up, dirVect);
        rb.MovePosition(rb.transform.position + dirVect * baseMoveSpeed * Time.deltaTime);
    }
}
