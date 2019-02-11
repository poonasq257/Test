using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class GrandmaHouseManager : MonoBehaviour
{
    public GameObject player;
    public GameObject con_left;
    public GameObject con_right;
    public GameObject b_left;
    public GameObject b_right;

    public GameObject redStory;
    public GameObject wolfStory;
    public GameObject[] grannyHome_red;
    public GameObject[] grannyHome_wolf;

    public GameObject[] rocks;
    public GameObject door;

    public GameObject movePoint;
    private int moveNum;
    public Transform[] movePositions_red;
    public Transform[] movePositions_wolf;
    
    public int sceneNum;
    public int num_rock;
    public bool eatGrand;

    private bool isFadeInOut = false;

    // Use this for initialization
    void Start()
    {
        sceneNum = 0;
        num_rock = 0;
        eatGrand = false;

        switch (GameManager.Instance.Character)
        {
            case GameManager.PlayableCharacter.Red:
                redStory.SetActive(true);
                wolfStory.SetActive(false);
                break;
            case GameManager.PlayableCharacter.Wolf:
                wolfStory.SetActive(true);
                redStory.SetActive(false);
                break;
        }

        if (GameManager.Instance.getwhichHandGrap() == 1)
        {
            b_left.SetActive(true);
            con_left.GetComponent<Grab_Object>().isGetBasket = true;
        }

        if (GameManager.Instance.getwhichHandGrap() == 2)
        {
            b_right.SetActive(true);
            con_right.GetComponent<Grab_Object>().isGetBasket = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        switch (GameManager.Instance.Character)
        {
            case GameManager.PlayableCharacter.Red: Red(); break;
            case GameManager.PlayableCharacter.Wolf: Wolf(); break;
        }
    }

    void Red()
    {
        if (sceneNum == 0)
        {
            movePoint.SetActive(true);
            if (movePoint.GetComponent<CheckCollision>().isColliding)
            {
                GameManager.Instance.isFreezing = true;
                movePoint.SetActive(false);
                grannyHome_red[0].SetActive(true);
                if (grannyHome_red[0].GetComponent<PlayableDirector>().state != PlayState.Playing)
                {
                    SteamVR_Fade.Start(Color.black, 0.0f);
                    sceneNum = 1;
                }
            }
        }
        else if (sceneNum == 1)
        {
            grannyHome_red[1].SetActive(true);
            if (grannyHome_red[1].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                player.transform.localPosition = movePositions_red[0].localPosition;
                SteamVR_Fade.Start(Color.clear, 0.0f);
                sceneNum = 2;
            }
        }
        else if (sceneNum == 2)
        {
            grannyHome_red[2].SetActive(true);
            if (grannyHome_red[2].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                foreach(GameObject obj in rocks)
                {
                    obj.SetActive(true);
                }
                if (num_rock == 1)
                {
                    sceneNum = 3;
                }
            }
        }
        else if (sceneNum == 3)
        {
            grannyHome_red[3].SetActive(true);
            if (grannyHome_red[3].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                GameManager.Instance.isFreezing = false;
                movePoint.transform.localPosition = movePositions_red[1].localPosition;
                movePoint.SetActive(true);
                if (movePoint.GetComponent<CheckCollision>().isColliding)
                {
                    GameManager.Instance.isFreezing = true;
                    movePoint.SetActive(false);
                    sceneNum = 4;
                }
            }
        }
        else if (sceneNum == 4)
        {
            grannyHome_red[4].SetActive(true);
            if (grannyHome_red[4].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                GameManager.Instance.isFreezing = false;
                GameManager.Instance.setwhichHandGrap(0);
                SceneManager.LoadScene("CourtHouse");
            }
        }
    }

    void Wolf()
    {
        if (sceneNum == 0)
        {
            grannyHome_wolf[0].SetActive(true);
            GameManager.Instance.isFreezing = true;
            if(grannyHome_wolf[0].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                GameManager.Instance.isFreezing = false;
                sceneNum = 1;
            }
        }
        else if (sceneNum == 1)
        {
            if (eatGrand == true)
            {
                movePoint.SetActive(true);
                if(movePoint.GetComponent<CheckCollision>().isColliding == true)
                {
                    FadeIn();
                    Invoke("FadeOut", 0.5f);
                    movePoint.SetActive(false);
                    player.transform.localPosition = movePositions_wolf[0].localPosition;
                    player.transform.localRotation = movePositions_wolf[0].localRotation;
                    sceneNum = 2;
                }
            }
        }
        else if (sceneNum == 2)
        {
            grannyHome_wolf[1].SetActive(true);
            GameManager.Instance.isFreezing = true;
            if (grannyHome_wolf[1].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                FadeIn();
                Invoke("FadeOut", 3.0f);
                sceneNum = 3;
            }
        }
        else if (sceneNum == 3)
        {
            if(!isFadeInOut) grannyHome_wolf[2].SetActive(true);
            GameManager.Instance.isFreezing = true;
            if (grannyHome_wolf[2].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                GameManager.Instance.isFreezing = false;
                movePoint.SetActive(true);
                movePoint.transform.localPosition = movePositions_wolf[1].localPosition;
                if (movePoint.GetComponent<CheckCollision>().isColliding)
                {
                    //door.GetComponent<PlayableDirector>().Play();
                    movePoint.transform.localPosition = movePositions_wolf[2].localPosition;
                    sceneNum = 4;
                }
            }
        }
        else if (sceneNum == 4)
        {
            if (door.GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                if (movePoint.GetComponent<CheckCollision>().isColliding)
                {
                    movePoint.SetActive(false);
                    SteamVR_Fade.Start(Color.black, 1.0f);
                    SteamVR_Fade.Start(Color.clear, 1.0f);
                    GameManager.Instance.setwhichHandGrap(0);
                    SceneManager.LoadScene("CourtHouse");
                }
            }
        }
    }

    private void FadeIn()
    {
        isFadeInOut = true;
        SteamVR_Fade.Start(Color.black, 0.0f);
    }

    private void FadeOut()
    {
        isFadeInOut = false;
        SteamVR_Fade.Start(Color.clear, 1.0f);
    }
}
