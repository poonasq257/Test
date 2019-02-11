using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;

public class ForestManager : MonoBehaviour {

    public GameObject con_left;
    public GameObject con_right;
    public GameObject b_left;
    public GameObject b_right;

    public GameObject[] redScenes;
    public GameObject[] wolfScenes;
    private int sceneNum;

    public GameObject redStory;
    public GameObject wolfStory;

    private GameObject movePoint;
    private int moveNum;
    public Transform[] movePositions_red;
    public Transform[] movePositions_wolf;

    // Use this for initialization
    void Start ()
    {
        sceneNum = 0;
        moveNum = 0;

        if (GameManager.Instance.Character == GameManager.PlayableCharacter.Red)
        {
            redStory.SetActive(true);
            wolfStory.SetActive(false);
            movePoint = redStory.transform.Find("Move Point").gameObject;
            movePoint.transform.localPosition = movePositions_red[sceneNum].localPosition;
        }
        else if (GameManager.Instance.Character == GameManager.PlayableCharacter.Wolf)
        {
            wolfStory.SetActive(true);
            redStory.SetActive(false);
            movePoint = wolfStory.transform.Find("Move Point").gameObject;
            movePoint.transform.localPosition = movePositions_wolf[sceneNum].localPosition;
        }

        if(GameManager.Instance.getwhichHandGrap() == 1)
        {
            b_left.SetActive(true);
            con_left.GetComponent<Grab_Object>().isGetBasket = true;
        }
        else if (GameManager.Instance.getwhichHandGrap() == 2)
        {
            b_right.SetActive(true);
            con_right.GetComponent<Grab_Object>().isGetBasket = true;
        }
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (redStory.activeSelf) Red();
        else if (wolfStory.activeSelf) Wolf();
    }

    void Red()
    {
        if (movePoint.activeSelf)
        {
            if (movePoint.GetComponent<CheckCollision>().isColliding)
            {
                redStory.transform.Find("Wolf").gameObject.SetActive(true);
                movePoint.SetActive(false);
                GameManager.Instance.isFreezing = true;
            }
            else return;
        }

        if (redScenes.Length <= sceneNum)
        {
            SceneManager.LoadScene("GrandmaHouse");
            return;
        }

        redScenes[sceneNum].SetActive(true);
        if(redScenes[sceneNum].GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            redScenes[sceneNum].SetActive(false);
            GameManager.Instance.isFreezing = false;
            ++sceneNum;

            if (movePositions_red.Length <= moveNum) return;
            movePoint.transform.localPosition = movePositions_red[++moveNum].localPosition;
            movePoint.SetActive(true);
        }
    }

    void Wolf()
    {
        if (movePoint.activeSelf)
        {
            if (movePoint.GetComponent<CheckCollision>().isColliding)
            {
                wolfStory.transform.Find("RedHood").gameObject.SetActive(true);
                movePoint.SetActive(false);
                GameManager.Instance.isFreezing = true;
            }
            else return;
        }

        if (wolfScenes.Length <= sceneNum)
        {
            SceneManager.LoadScene("GrandmaHouse");
            return;
        }

        wolfScenes[sceneNum].SetActive(true);
        if (wolfScenes[sceneNum].GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            if (sceneNum == 0 || sceneNum == 2)
            {
                if (movePositions_wolf.Length <= moveNum) return;
                movePoint.transform.localPosition = movePositions_wolf[moveNum++].localPosition;
                movePoint.SetActive(true);
                GameManager.Instance.isFreezing = false;
            }
            wolfScenes[sceneNum].SetActive(false);
            ++sceneNum;
        }
    }
}
