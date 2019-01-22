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

    public GameObject Scene1;
    public GameObject[] moves;

    public Text myText;

    public int num;

    // Use this for initialization
    void Start()
    {
        num = 0;
    }

    // Update is called once per frame
    void Update()
    {

        if (Scene1.GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            if (con_left.GetComponent<Grab_Object>().isGetBasket == false && con_right.GetComponent<Grab_Object>().isGetBasket == false)
            {
                TextUpdate();
            }

            if (con_left.GetComponent<Grab_Object>().isGetBasket == true || con_right.GetComponent<Grab_Object>().isGetBasket == true)
            {
                moves[0].SetActive(true);

                num = 1;
            }
        }

        if(num == 1 && moves[0].GetComponent<PlayableDirector>().state != PlayState.Playing)
        {
            SceneManager.LoadScene("Forest");
        }




    }

    void TextUpdate()
    {
        myText.text = "바구니를 집으세요.";
    }
}
