using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{

    public Canvas poziomUkonczony;
    public Canvas poziomNieukonczony;

    void Awake(){
        if (GameObject.FindGameObjectsWithTag("UIManager").Length > 1) Destroy(this.gameObject);
    }

    void Start(){
        DontDestroyOnLoad(this.gameObject);
        GameObject.Find("NextLevelButton").GetComponent<Button>().onClick.AddListener(GameManager.LoadNextLevel);
        GameObject.Find("MenuButtonNext").GetComponent<Button>().onClick.AddListener(GameManager.LoadMenu);
        GameObject.Find("RestartLevelButton").GetComponent<Button>().onClick.AddListener(GameManager.RestartLevel);
        GameObject.Find("MenuButtonRestart").GetComponent<Button>().onClick.AddListener(GameManager.LoadMenu);
    }

    void Update(){
        if (GameManager.showCompleteLevelWindow){
            poziomUkonczony.enabled = true;
            poziomNieukonczony.enabled = false;
        }
        else if (GameManager.showLoseLevelWindow){
            poziomUkonczony.enabled = false;
            poziomNieukonczony.enabled = true;
        }
        else{
            poziomNieukonczony.enabled = false;
            poziomUkonczony.enabled = false;
        }
    }
}
