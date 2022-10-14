using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour{

    public static int level = 1;
    public static int points = 0;

    private static Dictionary<string, int> pointsForLevel = new Dictionary<string, int>();

    void Start() {
        pointsForLevel["Main"] = 3;
        pointsForLevel["Level 2"] = 3;
    }

    void Update() { }

    public static void AddPoint()
    {
        points++;
        if (!pointsForLevel.ContainsKey("Level " + (level + 1))) return;
        if(pointsForLevel["Level " + (level + 1)] == points)
        {
            level++;
            points = 0;
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene("Level " + level);
        }
    }

    public static void Restart()
    {
        level = 1;
        points = 0;
    }
}
