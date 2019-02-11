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
        Grandma,
    }

    public GameLanguage language = GameLanguage.KR;
    private PlayableCharacter character = PlayableCharacter.Red;
    public bool isFreezing = false;
    public bool isSetting = false;
    public int whichHandGrap = 0;
    public PlayableCharacter[] playedCharacter = new PlayableCharacter[3];
    public int playTimes = 0;

    public PlayableCharacter Character
    {
        get { return instance.character; }
        set { instance.character = value; }
    }

    public void SetCharacter(string tag)
    {
        switch(tag)
        {
            case "Red":
                instance.character = PlayableCharacter.Red;
                instance.playedCharacter[instance.playTimes] = PlayableCharacter.Red;
                if(instance.playedCharacter.Length > instance.playTimes) instance.playTimes++;
                break;
            case "Wolf":
                instance.character = PlayableCharacter.Wolf;
                instance.playedCharacter[instance.playTimes] = PlayableCharacter.Wolf;
                if (instance.playedCharacter.Length > instance.playTimes) instance.playTimes++;
                break;
            case "Grandma":
                instance.character = PlayableCharacter.Grandma;
                instance.playedCharacter[instance.playTimes] = PlayableCharacter.Grandma;
                if (instance.playedCharacter.Length > instance.playTimes) instance.playTimes++;
                break;
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
