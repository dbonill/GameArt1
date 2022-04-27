using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameCommands : MonoBehaviour
{
    public GameObject player;
    public static bool GodMode = true;
    public static bool StopSwordSpawns = false;
    public static bool StopEnemySpawns = false;
    public static bool ControlEnemy = false;

    public Text godmodeT;
    public Text swordspawnsT;
    public Text enemyspawnsT;

    void updateText()
    {
        if (GodMode)
            godmodeT.text = "godmode: enabled";
        else
            godmodeT.text = "godmode: disabled";

        if (StopSwordSpawns)
            swordspawnsT.text = "sword spawns: disabled";
        else
            swordspawnsT.text = "sword spawns: enabled";

        if (StopEnemySpawns)
            enemyspawnsT.text = "enemy spawns: disabled";
        else
            enemyspawnsT.text = "enemy spawns: enabled";

    }

    private void Start()
    {
        updateText();
    }


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

        if (Input.GetKeyDown(KeyCode.F))
        {
            //GODMODE
            if (GodMode)
                GodMode = false;
            else
                GodMode = true;
            updateText();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            if (StopSwordSpawns)
                StopSwordSpawns = false;
            else
                StopSwordSpawns = true;
            updateText();

        }
        if (Input.GetKeyDown(KeyCode.E)) //disable Spawns
        {
            if (StopEnemySpawns)
                StopEnemySpawns = false;
            else
                StopEnemySpawns = true;
            updateText();

        }
        if (Input.GetKeyDown(KeyCode.LeftShift)) //control EC
        {
            if (ControlEnemy)
                ControlEnemy = false;
            else
                ControlEnemy = true;

        }



        if (player == null)
        {
            SceneManager.LoadScene("SampleScene");
        }

    }
}
