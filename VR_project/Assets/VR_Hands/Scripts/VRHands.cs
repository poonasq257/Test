using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VR;

public class VRHands : MonoBehaviour {
[SerializeField]
    private Valve.VR.InteractionSystem.Hand hand = null;
    private handGestures _handGest;
    public int _handNo;
    public bool _trigger;
    public bool _touchPressMiddle;

    private bool _touchPress;
	public bool _touchPressRight;
	public bool _touchPressLeft;
	public bool _touchPressUp;
	public bool _touchPressDown;
    public bool _grip;

[Range (-1f,1f)]
    private float _touchX;
[Range (-1f,1f)]
    private float _touchY;

    private float _triggerAmount;

public Vector2 _swipeStart;
public Vector2 _swipeEnd;
public float _currentSwipe;
[Header ("Swipe Detect")]
public float _minSwipe;
private SteamVR_Controller.Device device;

[Header ("Animations")]

public int _triggerAnim;
public int _gripAnim;
public int _touchMiddleAnim;
public int _touchLeftAnim;
public int _touchRightAnim;
public int _touchUpAnim;
public int _touchDownAnim;
public int _swipeLeftAnim;
public int _swipeRightAnim;



    
   

    private void Awake()
    {
      //  mTrackeObject = GetComponent<SteamVR_TrackedObject>();
      
    }

    // Use this for initialization
    void Start () {
        _handGest = GetComponentInChildren<handGestures>();
		hand= GetComponentInParent<Valve.VR.InteractionSystem.Hand>();
if(GetComponentInChildren<SteamVR_RenderModel>() != null){
		GameObject _defaultModel = GetComponentInChildren<SteamVR_RenderModel>().gameObject;
		_defaultModel.SetActive(false);
}

device = SteamVR_Controller.Input((int)hand.controller.index);


	}


	
	// Update is called once per frame
	void Update () {

//ANIMATIONS
if (_trigger){
    AnimateHand(_triggerAnim);
}
if(_grip){
    AnimateHand(_gripAnim);
}

if(_touchPressMiddle){
        AnimateHand(_touchMiddleAnim);

}

if(_touchPressLeft){
        AnimateHand(_touchLeftAnim);

}

if(_touchPressRight){
        AnimateHand(_touchRightAnim);

}

if(_touchPressDown){
        AnimateHand(_touchDownAnim);

}

if(_touchPressUp){
        AnimateHand(_touchUpAnim);

}

_triggerAmount = hand.controller.GetAxis(Valve.VR.EVRButtonId.k_EButton_SteamVR_Trigger).x;

if(!_touchPress){
    _touchPressDown = false;
    _touchPressLeft = false;
    _touchPressMiddle = false;
    _touchPressRight = false;
    _touchPressUp = false;
}

        if (hand.controller == null) return;
        
_touchX = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x;
_touchY = device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y;

        if(_triggerAmount > 0.9f)
        {
           _trigger = true;
           
        }
         if(_triggerAmount < 0.9f)
        {
            _trigger = false;
            
        }

if(hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Trigger)){
    AnimateHand(0);
}

        if(hand.controller.GetPress(SteamVR_Controller.ButtonMask.Touchpad))
        {
            _touchPress = true;

        if(_touchX > 0.5f){
            _touchPressRight = true;
        }

        if(_touchX < -0.5f){
            _touchPressLeft = true;
        }

        if(_touchY > 0.5f){
            _touchPressUp = true;
        }

        if(_touchY < -0.5f){
            _touchPressDown = true;
        }

        if(_touchX < 0.5f && _touchX > -0.5f && _touchY < 0.5f && _touchY > -0.5f){
            _touchPressMiddle = true;
        }



            
        }

        if(hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Touchpad))
        {
        _touchPress = false;

        }
		
         if(hand.controller.GetPress(SteamVR_Controller.ButtonMask.Grip))
        {
            _grip = true;
            
        }

         if(hand.controller.GetPressUp(SteamVR_Controller.ButtonMask.Grip))
        {
            _grip = false;
        }

        if(!_trigger&& !_grip && !_touchPressMiddle){
          
        }

        // SWIPE ACTION

        if(hand.controller.GetTouchDown(SteamVR_Controller.ButtonMask.Touchpad)){
        _swipeStart = new Vector2(0,0);
        _swipeEnd = new Vector2(0,0);
        _currentSwipe = 0f;
        _swipeStart = new Vector2(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x, device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);
        
        }

        if(hand.controller.GetTouch(SteamVR_Controller.ButtonMask.Touchpad)){
        
        _swipeEnd = new Vector2(device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).x, device.GetAxis(Valve.VR.EVRButtonId.k_EButton_Axis0).y);

        }

         if(hand.controller.GetTouchUp(SteamVR_Controller.ButtonMask.Touchpad)){
        SwipeCalculate();
         }
       
    }
    void SwipeCalculate(){
_currentSwipe = _swipeEnd.x - _swipeStart.x;



if(_currentSwipe < 0 && _currentSwipe < (-1 * _minSwipe)){

SwipeLeft();

}
if(_currentSwipe > 0 && _currentSwipe > _minSwipe){

SwipeRight();

}

}
void SwipeUp(){
Debug.Log("swipe up");
}
void SwipeDown(){
Debug.Log("swipe down");
}

void SwipeRight(){
Debug.Log("swipe right");
AnimateHand(_swipeRightAnim);
}

void SwipeLeft(){
Debug.Log("swipe left");
AnimateHand(_swipeLeftAnim);
}

public void AnimateHand(int i){
    _handGest._handGestureNo = i;
}

}
