using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class RedHouseManager : MonoBehaviour
{
    public GameObject con_left;
    public GameObject con_right;

    public GameObject narration;
    public Text subTitle;
    
    private BoxCollider endZone;
    private bool isEnd = false;
    
    // Use this for initialization
    void Start()
    {
        endZone = GetComponent<BoxCollider>();
        endZone.enabled = false;
    }

    void OnTriggerEnter(Collider col)
    {
        if (con_left.GetComponent<Grab_Object>().isGetBasket == true
            || con_right.GetComponent<Grab_Object>().isGetBasket == true)
        {
            if (col.tag == "Left" || col.tag == "Right")
            {
                GetComponent<PlayableDirector>().Play();
                isEnd = true;
            }
        }
    }


    // Update is called once per frame
    void Update()
    {
        if (narration.GetComponent<PlayableDirector>().state != PlayState.Playing) endZone.enabled = true;

        if(isEnd == true && GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            SceneManager.LoadScene("Forest");
        }
    }

    void TextUpdate()
    {
        //myText.text = "바구니를 집으세요.";
    }
}