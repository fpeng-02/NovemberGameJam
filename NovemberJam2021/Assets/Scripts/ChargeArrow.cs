using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChargeArrow : MonoBehaviour
{
    Vector3 scale;

    // Start is called before the first frame update
    void Start()
    {
        scale = transform.localScale;
    }

    public void SetActive(bool active) { FillProp(0); gameObject.SetActive(active); }
    public void SetDirection(Vector2 dirVec) { transform.rotation = Quaternion.FromToRotation(Vector2.up, dirVec); }

    public void FillProp(float prop)
    {
        scale.y = prop * 2; // more strechy, maybe makes more impact (current max length is a bit small IMO)
        transform.localScale = scale;
    }
}
