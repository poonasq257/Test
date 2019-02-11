using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    public GameObject targetObj;
    public bool isColliding;

    void Start()
    {
        isColliding = false;
    }

    void OnEnable()
    {
        isColliding = false;
    }

    void OnDisable()
    {
        isColliding = false;
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == targetObj.tag)
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == targetObj.tag)
        {
            isColliding = false;
        }
    }
}
