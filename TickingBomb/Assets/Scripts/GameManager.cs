using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public float timer;

    public Text timeText;

    public PlayerCameraMovement PCMX, PCMY;

    public Interaction IT;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        int seconds = (int)(timer % 60);
        int minutes = (int)(timer / 60) % 60;

        string timerString = string.Format("{0:00}:{1:00}", minutes, seconds);

        timeText.text = timerString;

        if (timer <= 30)
        {
            timeText.text = "Time Left: " + timer.ToString("F2");
        }
        else
        {
            timeText.text = "Time Left: " + timerString;
        }

        if (timer <= 0)
        {
            timer = 0f;
            Time.timeScale = 0f;
            PCMX.canMove = false;
            PCMY.canMove = false;
            IT.youLost.SetActive(true);
            IT.inGameHUD.SetActive(false);
            Cursor.visible = true;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}