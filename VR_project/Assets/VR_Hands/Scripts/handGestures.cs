using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handGestures : MonoBehaviour {
private Animator _handAnimator;
public int _handGestureNo;
	// Use this for initialization
	void Start () {
		_handAnimator = GetComponentInChildren<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		_handAnimator.SetInteger("handStatus", _handGestureNo);
	}

	public void SetGesture(int i){
		_handGestureNo = i;
	}
}
