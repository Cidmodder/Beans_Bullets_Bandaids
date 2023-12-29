using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public float timeRemaining = 60;
    public TextMeshProUGUI timerText;
    public GameObject commander;

    private float wave1;
    private float wave2;
    private float wave3;

    private int wave;
    
    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        wave1 = timeRemaining;
        wave2 = timeRemaining * (2f/3f);
        wave3 = timeRemaining * (1f/3f);

    }

    // Update is called once per frame
    void Update()
    {
        if (timeRemaining > wave3 && timeRemaining < wave2 && wave == 1)
        {
            commander.GetComponent<commanderAI>().setWave(2);
            wave++;
        }

        if (timeRemaining < wave3 && wave == 2)
        {
            commander.GetComponent<commanderAI>().setWave(3);
            wave++;
        }


        if (timeRemaining > 0)
        {
            timeRemaining -= Time.deltaTime;
            updateTime(timeRemaining);
        }

        else
        {
            timeRemaining = 0;
        }
    }

    public void updateTime(float time)
    {
        if (time < 0)
        {
           time = 0;
        }

        float minutes = Mathf.FloorToInt(time / 60);
        float seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{00:00}:{01:00}", minutes, seconds);
    }
}
