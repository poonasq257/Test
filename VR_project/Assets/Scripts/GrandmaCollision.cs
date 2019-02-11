using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrandmaCollision : MonoBehaviour {

    public GameObject particle;
    private GrandmaHouseManager myGrandmaHouse;

    // Use this for initialization
    void Start () {
        myGrandmaHouse = GameObject.Find("GrandmaHouseManager").GetComponent<GrandmaHouseManager>();
        this.gameObject.GetComponent<BoxCollider>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(myGrandmaHouse.sceneNum==1)
        {
            this.gameObject.GetComponent<BoxCollider>().enabled = true;
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hands")
        {
            myGrandmaHouse.eatGrand = true;
            particle.SetActive(true);
            this.gameObject.SetActive(false);
            particle.GetComponent<ParticleSystem>().Play();
        }
    }
}
