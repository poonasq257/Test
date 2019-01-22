using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GrandmaHouseManager : MonoBehaviour {

    public GameObject con_left;
    public GameObject con_right;
    public GameObject b_left;
    public GameObject b_right;

    public GameObject[] Scene;
    public GameObject[] Moves;
    public GameObject wolfStory;
    public GameObject redStory;

    public int num = 0;
    public int num_rock = 0;
    public bool eatGand = false;

    // Use this for initialization
    void Start () {
        if (GameManager.instance.ch == 1)//빨간모자
        {
            redStory.SetActive(true);
            wolfStory.SetActive(false);
        }

        if (GameManager.instance.ch == 2)//늑대
        {
            wolfStory.SetActive(true);
            redStory.SetActive(false);
        }

        if (GameManager.instance.getwhichHandGrap() == 1)
        {
            b_left.SetActive(true);
            con_left.GetComponent<Grab_Object>().isGetBasket = true;
        }

        if (GameManager.instance.getwhichHandGrap() == 2)
        {
            b_right.SetActive(true);
            con_right.GetComponent<Grab_Object>().isGetBasket = true;
        }
    }
	
	// Update is called once per frame
	void Update () {

        if (GameManager.instance.ch == 1)
        {
            Red();
        }

        if (GameManager.instance.ch == 2)
        {
            Wolf();
        }

    }

    void Red()
    {
        if (num == 0 && Moves[0].GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            Scene[0].SetActive(true);
            if (Scene[0].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 1;
                SteamVR_Fade.Start(Color.black, 0);
                b_left.SetActive(false);
                b_right.SetActive(false);
                con_left.GetComponent<Grab_Object>().isGetBasket = false;
                con_right.GetComponent<Grab_Object>().isGetBasket = false;
            }
        }
        else if (num == 1)
        {
            Scene[1].SetActive(true);
            if (Scene[1].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                SteamVR_Fade.Start(Color.clear, 1);
                num = 2;
            }
        }
        else if (num == 2)
        {
            Scene[2].SetActive(true);
            if (Scene[2].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 3;
            }
        }
        else if (num == 3)
        {
            Moves[1].SetActive(true);
            if (Scene[1].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 4;
            }
        }
        else if (num == 4)
        {
            if (num_rock == 1)
            {
                Scene[3].SetActive(true);
                if (Scene[3].GetComponent<PlayableDirector>().state != PlayState.Playing)
                {
                    num = 5;
                }
            }
        }
        else if (num == 5)
        {
            Moves[2].SetActive(true);
            if (Moves[2].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 6;
            }
        }
        else if (num == 6)
        {
            Scene[4].SetActive(true);
            if (Scene[4].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 0;
                num_rock = 0;
                GameManager.instance.setCh(0);
                GameManager.instance.setwhichHandGrap(0);
                SceneManager.LoadScene("Title");
            }
        }
    }

    void Wolf()
    {
        if (num == 0 && Scene[5].GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            num = 1;
        }
        else if(num ==1)
        {
            if(eatGand==true)
            {
                Moves[3].SetActive(true);

                if (Moves[3].GetComponent<PlayableDirector>().state != PlayState.Playing)
                {
                    num = 2;
                }
            }
        }
        else if(num==2)
        {
            Scene[6].SetActive(true);
            if (Scene[6].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 3;
            }
        }
        else if(num==3)
        {
            Moves[4].SetActive(true);
            SteamVR_Fade.Start(Color.black, 0);
            if (Moves[4].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                 SteamVR_Fade.Start(Color.clear, 1);
                num = 4;
            }
        }

        else if (num == 4)
        {
            Scene[7].SetActive(true);
            if (Scene[7].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                num = 5;
            }
        }
        else if(num==5)
        {
            Moves[5].SetActive(true);
            SteamVR_Fade.Start(Color.black, 0);
            if (Moves[5].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                SteamVR_Fade.Start(Color.clear, 1);
                num = 0;
                eatGand = false;
                GameManager.instance.setCh(0);
                GameManager.instance.setwhichHandGrap(0);
                SceneManager.LoadScene("Title");
            }
        }
    }
}
