using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Exit : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        bool Exit = Input.GetKeyDown(KeyCode.Escape);
        if(Exit) {
            Debug.Log("Exit"); 
            Application.Quit();
        }
    }
}
