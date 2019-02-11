using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class FlashbackManager : MonoBehaviour {
    public GameObject[] timeline;

	// Use this for initialization
	void Start () {
	}

    // Update is called once per frame
    void Update()
    {
        if (timeline[0].GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            timeline[1].SetActive(true);
            if (timeline[1].GetComponent<PlayableDirector>().state != PlayState.Playing)
            {
                SceneManager.LoadScene("CourtHouse");
            }
        }
    }
}
