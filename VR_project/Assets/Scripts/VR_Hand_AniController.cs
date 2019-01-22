using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VR_Hand_AniController : MonoBehaviour
{

    private Animator anim;

    private TriggerManager trigger;
    public GameObject controller;
    public GameObject hand_model;

    private Grab_Object grab;

    // Use this for initialization
    void Start()
    {
        anim = hand_model.GetComponent<Animator>();
        trigger = controller.GetComponent<TriggerManager>();
        grab = this.gameObject.GetComponent<Grab_Object>();
    }

    // Update is called once per frame
    void Update()
    {
        if (grab.isGetBasket)
        {
            anim.SetBool("IsTrigger", true);
        }
        else
        {
            if (trigger.IsGrab)
            {
                anim.SetBool("IsTrigger", true);
            }
            else
            {
                anim.SetBool("IsTrigger", false);
            }
        }

    }
}
