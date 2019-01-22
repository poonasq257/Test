using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket_Controller : MonoBehaviour {

    public GameObject cake1;
    public GameObject cake2;
    public GameObject wine;
    public bool getItemAll = false;

    private int num = 0;
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
	    if(num == 3)
        {
            getItemAll = true;
        }
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Cake1")
        {
            other.gameObject.SetActive(false);
            cake1.SetActive(true);
            num++;
        }
        else if (other.gameObject.tag == "Cake2")
        {
            other.gameObject.SetActive(false);
            cake2.SetActive(true);
            num++;
        }
        else if (other.gameObject.tag == "Wine")
        {
            other.gameObject.SetActive(false);
            wine.SetActive(true);
            num++;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Cake1")
        {
            other.gameObject.SetActive(false);
            cake1.SetActive(true);
            num++;
        }
        else if (other.gameObject.tag == "Cake2")
        {
            other.gameObject.SetActive(false);
            cake2.SetActive(true);
            num++;
        }
        else if (other.gameObject.tag == "Wine")
        {
            other.gameObject.SetActive(false);
            wine.SetActive(true);
            num++;
        }
    }
}
