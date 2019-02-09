using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour {
    public int times;
    public GameManager.PlayableCharacter character;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        GameManager.Instance.Character = character;
        GameManager.Instance.playTimes = times;
        Debug.Log(GameManager.Instance.Character);
        Debug.Log(GameManager.Instance.playTimes);
	}
}
