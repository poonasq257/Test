using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animationRectangle : MonoBehaviour {
[SerializeField]
private VRHands _vrHands;
public int _animNumber;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

void OnTriggerEnter(Collider c){
	if(c.gameObject.GetComponent<VRHands>() != null){
		_vrHands = c.GetComponent<VRHands>();

		_vrHands.AnimateHand(_animNumber);

	}
}

}
