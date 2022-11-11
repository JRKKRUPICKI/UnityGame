using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointSpinning : MonoBehaviour{

    void Update(){
        if (GameManager.showPauseGameWindow) return;
        transform.Rotate(new Vector3(4, 10, 0) * Time.deltaTime * 20);
    }
}
