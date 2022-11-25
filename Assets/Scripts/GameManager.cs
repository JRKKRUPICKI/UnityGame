using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour{

    public static int currentLevel = 1;
    public static int points = 0;

    public static Dictionary<string, int> pointsForLevel = new Dictionary<string, int>();

    public static bool showLevelCompletedWindow;
    public static bool showLevelUncompletedWindow;
    public static bool showPauseGameWindow;

    private static SoundManager soundManager;

    void Awake(){
        pointsForLevel["Level 1"] = 3;
        pointsForLevel["Level 2"] = 3;
        pointsForLevel["Level 3"] = 2;
        pointsForLevel["Level 4"] = 2;
        pointsForLevel["Level 5"] = 3;
        pointsForLevel["Level 6"] = 9;
        pointsForLevel["Level 7"] = 2;
        pointsForLevel["Level 8"] = 4;
        pointsForLevel["Level 10"] = 103;
    }

    void Start() {
        currentLevel = PlayerPrefs.GetInt("Current Level");
        pointsForLevel["Level 1"] = 3;
        pointsForLevel["Level 2"] = 3;
        pointsForLevel["Level 3"] = 2;
        pointsForLevel["Level 4"] = 2;
        pointsForLevel["Level 5"] = 3;
        pointsForLevel["Level 6"] = 9;
        pointsForLevel["Level 7"] = 2;
        pointsForLevel["Level 8"] = 4;
        pointsForLevel["Level 10"] = 103;
        soundManager = GameObject.FindGameObjectWithTag("SoundManager").GetComponent<SoundManager>();
        points = 0;
    }

    void Update() {
        if (GameManager.showLevelCompletedWindow || GameManager.showLevelUncompletedWindow) GameObject.Find("Canvas").GetComponent<Canvas>().enabled = false;
        if (Input.GetKeyDown(KeyCode.Escape)) showPauseGameWindow = !showPauseGameWindow;
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
        showLevelUncompletedWindow = false;
        showPauseGameWindow = false;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public static void SetNextLevel(){
        currentLevel++;
        points = 0;
        PlayerPrefs.SetInt("Current Level", currentLevel);
    }

    public static void LoadNextLevel(){
        showLevelCompletedWindow = false;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    public static void LoadMenu(){
        points = 0;
        showLevelCompletedWindow = false;
        showLevelUncompletedWindow = false;
        showPauseGameWindow = false;
        SceneManager.LoadScene("Menu");
    }
}
