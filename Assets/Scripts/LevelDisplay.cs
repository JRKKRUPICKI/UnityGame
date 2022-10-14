using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelDisplay : MonoBehaviour{

    public TextMeshProUGUI levelText;
    public TextMeshProUGUI pointsText;

    void Update(){
        levelText.text = "Poziom: " + GameController.level;
        pointsText.text = "Punkty: " + GameController.points + "/3";
    }
}
