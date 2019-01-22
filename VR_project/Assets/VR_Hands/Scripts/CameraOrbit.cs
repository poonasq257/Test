using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraOrbit : MonoBehaviour {
public float _speed;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButton(0)){
		transform.Rotate(Input.GetAxis("Mouse Y")*_speed, Input.GetAxis("Mouse X")*_speed, 0 * Time.unscaledDeltaTime);
		}

		if(Input.GetMouseButtonDown(1)){
		ResetRotation();
		}

		
	}

	public void ResetRotation(){
		transform.rotation = Quaternion.identity;
	}
}
