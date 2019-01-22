using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

    public static GameManager instance = null;

    public int ch = 1;
    public bool isSetting = false;
    public int whichHandGrap = 0;

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

    public void setCh(int num)
    {
        ch = num;
    }

    public int getCh()
    {
        return ch;
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

}
