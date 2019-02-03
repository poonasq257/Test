using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MultipleLanguage : MonoBehaviour {
    public Text textComponent;
    public string korean;
    public string english;
    
    void Awake() {
        textComponent = GetComponent<Text>();
    }

    void Start() {
        SetLanguage();
    }

    void OnEnable() {
        SetLanguage();
    }

    private void SetLanguage()
    {
        switch (GameManager.Instance.language)
        {
            case GameManager.GameLanguage.KR: textComponent.text = korean; break;
            case GameManager.GameLanguage.EN: textComponent.text = english; break;
        }
    }
}
