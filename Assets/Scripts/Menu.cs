using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnGUI()
    {
        if(GUI.Button(new Rect(10, 10, 100, 50), "Graj"))
        {
            SceneManager.LoadScene(1);
            return;
        }
        if (GUI.Button(new Rect(10, 70, 100, 50), "Wyjd�"))
        {
            Application.Quit();
        }
    }
}
