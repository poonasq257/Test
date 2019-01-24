using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public enum GameLanguage
    {
        KR,
        EN,
    }

    public enum PlayableCharacter
    {
        None,
        Red,
        Wolf,
    }

    public GameLanguage language = GameLanguage.KR;
    private PlayableCharacter character = PlayableCharacter.Red;
    public bool isSetting = false;
    public int whichHandGrap = 0;

    public PlayableCharacter Character
    {
        get { return character; }
        set { character = value; }
    }

    void Awake()
    {
        if (instance == null)
            instance = this;

        else if (instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {

    }

    void Update()
    {

    }

    public void DoHello()
    {
        Debug.Log("Hello");
    }

    public void SetCharacter(string charName)
    {
        switch(charName)
        {
            case "None": character = PlayableCharacter.None; break;
            case "Red": character = PlayableCharacter.Red; break;
            case "Wolf": character = PlayableCharacter.Wolf; break;
        }
    }

    public void setwhichHandGrap(int num)
    {
        whichHandGrap = num;
    }

    public int getwhichHandGrap()
    {
        return whichHandGrap;
    }

    public void setIsSetting(bool myset)
    {
        isSetting = myset;
    }

    public bool getIsSetting()
    {
        return isSetting;
    }

    public void NextScene()
    {
        switch(character)
        {
            case PlayableCharacter.Red: SceneManager.LoadScene("RedHouse");break;
            case PlayableCharacter.Wolf: SceneManager.LoadScene("Forest"); break;
        }
    }
}
