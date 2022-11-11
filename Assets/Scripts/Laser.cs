using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour{

    public GameObject laser;
    public float showTime;
    public float hideTime;
    float changeTime;

    void Update(){
        if (GameManager.showPauseGameWindow) return;
        changeTime += Time.deltaTime;
        if (laser.activeSelf && changeTime > showTime || !laser.activeSelf && changeTime > hideTime){
            laser.SetActive(!laser.activeSelf);
            changeTime = 0;
        }
    }
}
