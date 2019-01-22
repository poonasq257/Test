using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

    public string button_name;

    public GameObject con_left;
    public GameObject con_right;

    private TriggerManager trigger;
    private TriggerManager trigger2;

    public GameObject main_play;
    public GameObject main_Quit;

    public GameObject paly_red;
    public GameObject paly_wolf;
    public GameObject paly_back;

    // Use this for initialization
    void Start () {
        trigger = con_left.GetComponent<TriggerManager>();
        trigger2 = con_right.GetComponent<TriggerManager>();
    }
	
	// Update is called once per frame
	void Update () {

        if (trigger.IsTriggerDown || trigger2.IsTriggerDown)
        {
            if (button_name == "PLAY")
            {
                main_play.GetComponent<Button>().onClick.Invoke();
                trigger.IsTriggerDown = false;
                trigger2.IsTriggerDown = false;
            }

            else if (button_name == "QUIT")
            {
                main_Quit.GetComponent<Button>().onClick.Invoke();
                trigger.IsTriggerDown = false;
                trigger2.IsTriggerDown = false;
            }

            else if (button_name == "RED")
            {
                GameManager.instance.setCh(1);
                paly_red.GetComponent<Button>().onClick.Invoke();
                trigger.IsTriggerDown = false;
                trigger2.IsTriggerDown = false;
            }

            else if (button_name == "WOLF")
            {
                GameManager.instance.setCh(2);
                paly_wolf.GetComponent<Button>().onClick.Invoke();
                trigger.IsTriggerDown = false;
                trigger2.IsTriggerDown = false;
            }

            else if (button_name == "BACK")
            {
                paly_back.GetComponent<Button>().onClick.Invoke();
                trigger.IsTriggerDown = false;
                trigger2.IsTriggerDown = false;
            }
        }
    }

    public void Play_Red()
    {
        SceneManager.LoadScene("RedHouse");
    }

    public void Play_Wolf()
    {
        SceneManager.LoadScene("Forest");
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
