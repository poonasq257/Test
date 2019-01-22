using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerManager : MonoBehaviour {

    private SteamVR_TrackedObject trackedObj;

    public bool IsTriggerDown;
    public bool IsGrab;

    public SteamVR_Controller.Device Controller
    {
        get { return SteamVR_Controller.Input((int)trackedObj.index); }
    }

    void Awake()
    {
        trackedObj = GetComponent<SteamVR_TrackedObject>();
        IsTriggerDown = false;
        IsGrab = false;
    }

    void Update()
    {
        if(Controller.GetHairTriggerDown())
        {
            Controller.TriggerHapticPulse(3000);
            IsTriggerDown = false;
            IsGrab = true;
        }
        else if (Controller.GetHairTriggerUp())
        {
            IsTriggerDown = true;
            IsGrab = false;
        }
 
    }
}
