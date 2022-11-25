using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VerticalOpening : MonoBehaviour{

    private bool isOpen;
    public GameObject[] switchedPressurePlates;
    public bool[] values;

    void Start(){}

    void Update(){
        bool active = true;
        for(int i = 0; i < switchedPressurePlates.Length; i++){
            if(switchedPressurePlates[i].GetComponent<SwitchedPressurePlate>().isActive != values[i]){
                active = false;
            }
        }
        isOpen = active;
        Vector3 newPosition = GetComponent<Transform>().position;
        if (isOpen) newPosition.y = -0.55f;
        else newPosition.y = 0.5f;
        GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position, newPosition, 1 * Time.deltaTime);
    }
}
