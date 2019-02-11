using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class CourtHouseManager : MonoBehaviour {
    public GameObject[] timelines;
    private PlayableDirector[] playableDirectors;
    private int sceneNum = 0;

    void Start()
    {
        sceneNum = GameManager.Instance.playTimes;
        Debug.Log(sceneNum);

        playableDirectors = new PlayableDirector[timelines.Length];

        for(int i = 0; i < timelines.Length; i++)
        {
            playableDirectors[i] = timelines[i].GetComponent<PlayableDirector>();
        }
    }

    void Update ()
    {
        if(sceneNum < timelines.Length)

        timelines[sceneNum].SetActive(true);
        if(playableDirectors[sceneNum].state != PlayState.Playing)
        {
            GameManager.Instance.isFreezing = false;
        }
        else GameManager.Instance.isFreezing = true;
    }
}