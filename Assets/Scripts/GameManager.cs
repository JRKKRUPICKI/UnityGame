using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public static int currentLevel = 1;
    public static int points = 0;

    public static Dictionary<string, int> pointsForLevel = new Dictionary<string, int>();

    public static bool showCompleteLevelWindow;
    public static bool showLoseLevelWindow;

    private static SoundManager soundManager;

    void Start() {
        currentLevel = PlayerPrefs.GetInt("Current Level");
        pointsForLevel["Level 1"] = 3;
        pointsForLevel["Level 2"] = 3;
        pointsForLevel["Level 3"] = 2;
        pointsForLevel["Level 4"] = 2;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        points = 0;
    }

    void Update() {
        if (GameManager.showCompleteLevelWindow || GameManager.showLoseLevelWindow) GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
    }

    public static void AddPoint(){
        points++;
        if(IsNextLevelUnlocked()){
            if (GameObject.FindGameObjectsWithTag("DOOR").Length < 1) return;
            soundManager.PlaySound(SoundManager.Sound.unlock, GameObject.FindGameObjectWithTag("DOOR").GetComponent<Transform>().position);
        }
    }

    public static bool IsNextLevelUnlocked(){
        if (!pointsForLevel.ContainsKey("Level " + currentLevel)) return false;
        return pointsForLevel["Level " + currentLevel] == points;
    }

    public static void RestartLevel(){
        points = 0;
        showLoseLevelWindow = false;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public static void SetNextLevel(){
        currentLevel++;
        points = 0;
        PlayerPrefs.SetInt("Current Level", currentLevel);
    }

    public static void LoadNextLevel(){
        showCompleteLevelWindow = false;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public static void LoadMenu(){
        points = 0;
        showCompleteLevelWindow = false;
        showLoseLevelWindow = false;
        SceneManager.LoadScene("Menu");
    }
}
