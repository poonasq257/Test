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

    private enum ClickedButton
    {
        NONE = -1,
        PLAY,
        LANGUAGE,
        QUIT,
        FLASHBACK,
        COURTHOUSE,
        BACK_PLAY,
        RED,
        WOLF,
        BACK_FLASHBACK,
        KOREAN,
        ENGLISH,
        BACK_LANGUAGE,
    }

    private ClickedButton clickedButton;
    public GameObject[] buttons;
    
    // Use this for initialization
    void Start () {
        trigger = con_left.GetComponent<TriggerManager>();
        trigger2 = con_right.GetComponent<TriggerManager>();
        clickedButton = ClickedButton.NONE;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if (trigger.IsTriggerDown || trigger2.IsTriggerDown)
        {
            switch (button_name)
            {
                case "PLAY": clickedButton = ClickedButton.PLAY; break;
                case "LANGUAGE": clickedButton = ClickedButton.LANGUAGE; break;
                case "QUIT": clickedButton = ClickedButton.QUIT; break;
                case "FLASHBACK": clickedButton = ClickedButton.FLASHBACK; break;
                case "COURTHOUSE": clickedButton = ClickedButton.COURTHOUSE; break;
                case "BACK_PLAY": clickedButton = ClickedButton.BACK_PLAY; break;
                case "RED": clickedButton = ClickedButton.RED; break;
                case "WOLF": clickedButton = ClickedButton.WOLF; break;
                case "BACK_FLASHBACK": clickedButton = ClickedButton.BACK_FLASHBACK; break;
                case "KOREAN": clickedButton = ClickedButton.KOREAN; break;
                case "ENGLISH": clickedButton = ClickedButton.ENGLISH; break;
                case "BACK_LANGUAGE": clickedButton = ClickedButton.BACK_LANGUAGE; break;
                default: clickedButton = ClickedButton.NONE; break;
            }

            if (clickedButton != ClickedButton.NONE) buttons[(int)clickedButton].GetComponent<Button>().onClick.Invoke();
            trigger.IsTriggerDown = false;
            trigger2.IsTriggerDown = false;
        }
    }

    public void Play_Red()
    {
        GameManager.Instance.SetCharacter("Red");
        GameManager.Instance.NextScene();
    }

    public void Play_Wolf()
    {
        GameManager.Instance.SetCharacter("Wolf");
        GameManager.Instance.NextScene();
    }

    public void Play_Courthouse()
    {
        SceneManager.LoadScene("Courthouse");
    }

    public void ChangeLanguage_Korean()
    {
        GameManager.Instance.language = GameManager.GameLanguage.KR;
    }
    
    public void ChangeLanguage_English()
    {
        GameManager.Instance.language = GameManager.GameLanguage.EN;
    }

    public void QuitGame()
    {
        Application.Quit();
    }

}
