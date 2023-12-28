using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class timerScript : MonoBehaviour
{
    public float timeRemaining = 900;
    public TextMeshProUGUI timerText;
    
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

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
