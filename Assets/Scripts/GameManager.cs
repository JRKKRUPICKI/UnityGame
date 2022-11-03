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
    }

    void Update() { }

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

    void OnGUI(){
        if (showCompleteLevelWindow){
            Rect windowRect = new Rect((Screen.width - Screen.width / 2) / 2, (Screen.height - Screen.height / 2) / 2, Screen.width / 2, Screen.height / 2);
            GUI.Box(windowRect, "Poziom " + currentLevel + " ukoñczony");
            if(GUI.Button(new Rect(windowRect.x + windowRect.width / 2 - windowRect.width / 4, windowRect.y + windowRect.height / 2 - 70, windowRect.width / 2, 50), "Nastêpny poziom")){
                SetNextLevel();
                showCompleteLevelWindow = false;
                SceneManager.LoadScene("Level " + currentLevel);
            }
            if(GUI.Button(new Rect(windowRect.x + windowRect.width / 2 - windowRect.width / 4, windowRect.y + windowRect.height / 2, windowRect.width / 2, 50), "Menu")){
                SetNextLevel();
                showCompleteLevelWindow = false;
                SceneManager.LoadScene("Menu");
            }
        }
        if (showLoseLevelWindow)
        {
            Rect windowRect = new Rect((Screen.width - Screen.width / 2) / 2, (Screen.height - Screen.height / 2) / 2, Screen.width / 2, Screen.height / 2);
            GUI.Box(windowRect, "Poziom " + currentLevel + " nieukoñczony");
            if (GUI.Button(new Rect(windowRect.x + windowRect.width / 2 - windowRect.width / 4, windowRect.y + windowRect.height / 2 - 70, windowRect.width / 2, 50), "Restartuj poziom")){
                RestartLevel();
                showLoseLevelWindow = false;
            }
            if (GUI.Button(new Rect(windowRect.x + windowRect.width / 2 - windowRect.width / 4, windowRect.y + windowRect.height / 2, windowRect.width / 2, 50), "Menu")){
                points = 0;
                showLoseLevelWindow = false;
                SceneManager.LoadScene("Menu");
            }
        }
    }

    public static void RestartLevel(){
        points = 0;
        SceneManager.LoadScene("Level " + currentLevel);
    }

    void SetNextLevel(){
        currentLevel++;
        points = 0;
        PlayerPrefs.SetInt("Current Level", currentLevel);
    }
}
