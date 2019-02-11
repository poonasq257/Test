using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class test : MonoBehaviour {
    public bool court = false;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(court == true)
        {
            SceneManager.LoadScene("CourtHouse");
            court = false;
        }
	}
}
