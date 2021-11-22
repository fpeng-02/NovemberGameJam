using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float baseMoveSpeed;
    [SerializeField] private float reach;    // how far the player has to be from an interactable object to access it, i.e. distance of raycast
    [SerializeField] private float maxThrowPower;
    [SerializeField] private GameObject throwResultMarker;
    [SerializeField] private float powerDistScale;
    [SerializeField] private GameObject pot;
    [SerializeField] private ChargeArrow chargeArrow;
    private float h;
    private float v;
    private Vector3 dirVect;
    private Rigidbody2D rb;
    private bool throwing;
    private float throwPower;
    //private Ingredient ingredient = null;
    private GameObject ingredientGO;
    public static bool playingMinigame;
    private Animator animator;


    public void setIngredientGO (GameObject ingredientGO) { this.ingredientGO = ingredientGO; }
    public GameObject GetIngredientGO() { return ingredientGO; }

    public void SetPlayingMinigame (bool playing) { playingMinigame = playing; }
    public bool GetPlayingMinigame () { return playingMinigame; }

    //public void SetIngredient(Ingredient ing) { ingredient = ing; }
    //public Ingredient GetIngredient() { return ingredient; }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        throwing = false;
        ingredientGO = null;
        animator = GetComponent<Animator>();
        pot = GameObject.Find("Pot");
        chargeArrow.SetActive(false);
    }

    // Update is called once per frame
    void Update() {
        if (playingMinigame) return;

        h = Input.GetAxisRaw("Horizontal");
        v = Input.GetAxisRaw("Vertical");
        dirVect = (new Vector3(h, v, 0)).normalized;


        if(h == 0 && v == 0){
            animator.SetBool("isRunning", false);
        } else{
            animator.SetBool("isRunning", true);
        }

        if(GetIngredientGO() != null){
            animator.SetBool("isHolding", true);
        } else{
            animator.SetBool("isHolding", false);
        }
           
        //if throwing, don't let the player move
        if (throwing) {
            // TODO: fill some progress bar by (curr_power) / (maxthrowpower)
            chargeArrow.FillProp(Mathf.Min(1, 2*(Time.time - throwPower) / maxThrowPower));
            dirVect = Vector3.zero;
            Vector2 throwDir = pot.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector2.up, throwDir);
            if (Input.GetMouseButtonUp(1)) {
                throwPower = Mathf.Min(maxThrowPower, Time.time - throwPower);
                
                Vector3 throwVec = throwDir.normalized * throwPower * powerDistScale;

                ingredientGO.transform.parent = null;
                Rigidbody2D ingredientRigid = ingredientGO.GetComponent<Rigidbody2D>();
                ingredientRigid.bodyType = RigidbodyType2D.Dynamic;
                ingredientRigid.drag = 2f;
                ingredientRigid.AddForce(throwVec*100);
                

                //Instantiate(throwResultMarker, transform.position + throwVec, Quaternion.identity); 

                Debug.Log($"Pot pos {pot.transform.position}");
                Debug.Log($"This pos {transform.position}");
                Debug.Log($"{ingredientGO.GetComponent<Ingredient>().GetIngredientType().ToString()} thrown with {throwPower} force!");

                ingredientGO = null;
                //ingredient = null;

                throwing = false;   
                chargeArrow.SetActive(false);
            }
        }
        else {
            if (Input.GetMouseButtonDown(1)) {
                if (ingredientGO != null) {
                    throwing = true;

                    //TODO: change to decreased movement 
                    dirVect = Vector3.zero;

                    throwPower = Time.time;
                    chargeArrow.SetActive(true);
                    chargeArrow.transform.rotation = transform.rotation;
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
        if (dirVect.magnitude > 0){
            transform.rotation = Quaternion.FromToRotation(Vector2.up, dirVect);
        } 
        rb.velocity = dirVect * baseMoveSpeed * Time.deltaTime;
    }
}
