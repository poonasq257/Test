using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wolf_rock : MonoBehaviour {

    public GameObject particle;
    private GrandmaHouseManager myGrandmaHouse;

    // Use this for initialization
    void Start () {
        myGrandmaHouse = GameObject.Find("GrandmaHouseManager").GetComponent<GrandmaHouseManager>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag == "Rock")
        {
            particle.SetActive(true);
            other.gameObject.SetActive(false);
            particle.GetComponent<ParticleSystem>().Play();
            myGrandmaHouse.num_rock++;

            this.GetComponent<BoxCollider>().enabled = false;
        }
    }
}

