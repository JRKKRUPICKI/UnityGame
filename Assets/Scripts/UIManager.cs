using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour{

    public Canvas levelCompletedWindow;
    public Canvas levelUncompletedWindow;
    public Canvas pauseGameWindow;

    void Awake(){
        if (GameObject.FindGameObjectsWithTag("UIManager").Length > 1) Destroy(this.gameObject);
    }

    void Start(){
        DontDestroyOnLoad(this.gameObject);
        GameObject.Find("Next Level Button").GetComponent<Button>().onClick.AddListener(GameManager.LoadNextLevel);
        GameObject.Find("Menu Button 1").GetComponent<Button>().onClick.AddListener(GameManager.LoadMenu);
        GameObject.Find("Restart Level Button 1").GetComponent<Button>().onClick.AddListener(GameManager.RestartLevel);
        GameObject.Find("Menu Button 2").GetComponent<Button>().onClick.AddListener(GameManager.LoadMenu);
        GameObject.Find("Restart Level Button 2").GetComponent<Button>().onClick.AddListener(GameManager.RestartLevel);
        GameObject.Find("Menu Button 3").GetComponent<Button>().onClick.AddListener(GameManager.LoadMenu);
    }

    void Update(){
        if (GameManager.showLevelCompletedWindow){
            levelCompletedWindow.enabled = true;
            levelUncompletedWindow.enabled = false;
            pauseGameWindow.enabled = false;
        }
        else if (GameManager.showLevelUncompletedWindow){
            levelCompletedWindow.enabled = false;
            levelUncompletedWindow.enabled = true;
            pauseGameWindow.enabled = false;
        }
        else if (GameManager.showPauseGameWindow){
            levelCompletedWindow.enabled = false;
            levelUncompletedWindow.enabled = false;
            pauseGameWindow.enabled = true;
        }
        else{
            levelCompletedWindow.enabled = false;
            levelUncompletedWindow.enabled = false;
            pauseGameWindow.enabled = false;
        }
    }
}
