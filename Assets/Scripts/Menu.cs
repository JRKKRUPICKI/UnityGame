using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour{

    public Button continueButton;

    void Start(){}

    void Update(){
        if (PlayerPrefs.GetInt("Current Level") <= 1){
            continueButton.transform.localScale = new Vector3(0, 0, 0);
        }
    }

    public void ContinueGame(){
        if (PlayerPrefs.GetInt("Current Level") > 1){
            SceneManager.LoadScene("Level " + PlayerPrefs.GetInt("Current Level"));
            return;
        }
        NewGame();
    }

    public void NewGame(){
        SceneManager.LoadScene("Level 1");
        GameManager.currentLevel = 1;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 1);
    }

    public void QuitGame(){
        Application.Quit();
    }

    public void SelectLevel(){
        SceneManager.LoadScene("Select Level");
    }

    public void Controls(){
        SceneManager.LoadScene("Controls");
    }

    public void LoadLevel1(){
        SceneManager.LoadScene("Level 1");
        GameManager.currentLevel = 1;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 1);
    }

    public void LoadLevel2(){
        SceneManager.LoadScene("Level 2");
        GameManager.currentLevel = 2;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 2);
    }

    public void LoadLevel3(){
        SceneManager.LoadScene("Level 3");
        GameManager.currentLevel = 3;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 3);
    }

    public void LoadLevel4(){
        SceneManager.LoadScene("Level 4");
        GameManager.currentLevel = 4;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 4);
    }

    public void LoadLevel5(){
        SceneManager.LoadScene("Level 5");
        GameManager.currentLevel = 5;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 5);
    }

    public void LoadLevel6(){
        SceneManager.LoadScene("Level 6");
        GameManager.currentLevel = 6;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 6);
    }

    public void LoadLevel7(){
        SceneManager.LoadScene("Level 7");
        GameManager.currentLevel = 7;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 7);
    }

    public void LoadLevel8(){
        SceneManager.LoadScene("Level 8");
        GameManager.currentLevel = 8;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 8);
    }
    public void LoadLevel9(){
        SceneManager.LoadScene("Level 9");
        GameManager.currentLevel = 9;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 9);
    }

    public void LoadLevel10(){
        SceneManager.LoadScene("Level 10");
        GameManager.currentLevel = 10;
        GameManager.points = 0;
        PlayerPrefs.SetInt("Current Level", 10);
    }

    public void LoadMenu(){
        SceneManager.LoadScene("Menu");
    }
}
