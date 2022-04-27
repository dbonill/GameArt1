using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameCommands : MonoBehaviour
{
    public static bool ControlEnemy = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) //Escape to close game
        {
            Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            if (Time.timeScale == 1) //set time to 0 if paused otherwise set it back to normal
                Time.timeScale = 0;
            else
                Time.timeScale = 1;
        }

        if (Input.GetKeyDown(KeyCode.LeftShift)) //control EC
        {
            if (ControlEnemy)
                ControlEnemy = false;
            else
                ControlEnemy = true;

        }

    }
}
