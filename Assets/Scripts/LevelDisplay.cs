using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour{

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI pointsText;

    void Update(){
        levelText.text = "Poziom: " + GameManager.currentLevel;
        pointsText.text = "Punkty: " + GameManager.points + "/" + GameManager.pointsForLevel["Level " + GameManager.currentLevel];
    }
}
