using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckCollision : MonoBehaviour {
    public string targetTag;
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

    void OnCollisionEnter(Collision col)
    {
        if(col.collider.tag == targetTag)
        {
            isColliding = true;
        }
    }

    void OnCollisionExit(Collision col)
    {
        if (col.collider.tag == targetTag)
        {
            isColliding = false;
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == targetTag)
        {
            isColliding = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (collider.tag == targetTag)
        {
            isColliding = false;
        }
    }
}
