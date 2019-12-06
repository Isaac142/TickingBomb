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

    public GameObject youWin;
    public GameObject youLost;

    public GameObject inGameHUD;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;

        timer = 30f;

        Time.timeScale = 1f;
    }

    // Update is called once per frame
    void Update()
    {

        if (timer <= 5)
        {
            timeText.text = "Time Left: " + timer.ToString("F2");
        }
        else
        {
            timeText.text = "Time Left: " + timer.ToString("F0");
        }

        if (timer <= 0)
        {
            timer = 0f;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}