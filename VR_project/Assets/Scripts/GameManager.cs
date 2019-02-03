using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager {
    private static GameManager instance = null;
    public static GameManager Instance
    {
        get
        {
            if (instance == null) instance = new GameManager();
            return instance;
        }
    }

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
        get { return instance.character; }
        set { instance.character = value; }
    }

    void Awake()
    {
        //if (instance == null)
        //    instance = this;

        //else if (instance != this)
        //    Destroy(gameObject);

        //DontDestroyOnLoad(gameObject);

        InitGame();
    }

    //Initializes the game for each level.
    void InitGame()
    {

    }

    void Update()
    {
    }
    
    public void SetCharacter(string charName)
    {
        switch(charName)
        {
            case "None": instance.character = PlayableCharacter.None; break;
            case "Red": instance.character = PlayableCharacter.Red; break;
            case "Wolf": instance.character = PlayableCharacter.Wolf; break;
        }
    }

    public void setwhichHandGrap(int num)
    {
        instance.whichHandGrap = num;
    }

    public int getwhichHandGrap()
    {
        return instance.whichHandGrap;
    }

    public void setIsSetting(bool myset)
    {
        instance.isSetting = myset;
    }

    public bool getIsSetting()
    {
        return instance.isSetting;
    }

    public void NextScene()
    {
        switch(instance.character)
        {
            case PlayableCharacter.Red: SceneManager.LoadScene("RedHouse");break;
            case PlayableCharacter.Wolf: SceneManager.LoadScene("Forest"); break;
        }
    }
}
