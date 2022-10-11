using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : MonoBehaviour
{
    public Transform[] patrolPoints;
    private float moveSpeed = 3;
    private int currentPoint = 0;
    public bool patrolLoop = false;
    private int nextPoint = 1;

    void Start()
    {
        if(patrolPoints.Length == 0) return;
        GetComponent<Transform>().position = patrolPoints[currentPoint].position;
    }

    void Update()
    {
        if(patrolPoints.Length == 0) return;
        if(GetComponent<Transform>().position == patrolPoints[currentPoint].position){
            if(patrolLoop){
                if(currentPoint == patrolPoints.Length - 1){
                    currentPoint = 0;
                }
                else{
                    currentPoint++;
                }
            }
            else{
                if(currentPoint == patrolPoints.Length - 1){
                    nextPoint = -1;
                }
                else if(currentPoint == 0){
                    nextPoint = 1;
                }
                currentPoint += nextPoint;
            }
        }
        GetComponent<Transform>().position = Vector3.MoveTowards(GetComponent<Transform>().position, patrolPoints[currentPoint].position, moveSpeed * Time.deltaTime);
    }
}
