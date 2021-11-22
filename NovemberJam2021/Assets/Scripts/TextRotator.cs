using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextRotator : MonoBehaviour
{
    Quaternion iniRot;
    [SerializeField] Vector3 textPos;
    // Start is called before the first frame update
    void Start()
    {
        iniRot = GetComponentInParent<Player>().transform.rotation;
        iniRot = transform.rotation;
        gameObject.SetActive(false);

    }

    void LateUpdate()
    {
        transform.rotation = iniRot;
        transform.position = GetComponentInParent<Player>().transform.position + textPos;
    }


 


    
}
