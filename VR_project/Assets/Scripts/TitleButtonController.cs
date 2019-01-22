using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleButtonController : MonoBehaviour {

    //private TriggerManager trigger;
    private MainMenu main;

	// Use this for initialization
	void Start () {
        //trigger = GetComponentInChildren<TriggerManager>();
        main = GameObject.Find("MainMenu").GetComponent<MainMenu>();
    }
	

    public void Get_ButtonName()
    {
        if(gameObject.activeInHierarchy)
        {
            main.button_name = gameObject.name;
        }
        
        //Debug.Log(main.button_name);
        //return gameObject.name;
    }

    public void Exit_ButtonName()
    {

        main.button_name = "";

    }
}
