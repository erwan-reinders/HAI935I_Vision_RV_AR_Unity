using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerBehavior : MonoBehaviour
{
    TMP_Text timerText;

    // Start is called before the first frame update
    void Start()
    {
        GameVariables.currentTime = GameVariables.allowedTime;
        timerText = GameObject.Find("timer").GetComponent<TMPro.TMP_Text>();

        timerText.text = "Time : " + GameVariables.currentTime.ToString();
        StartCoroutine(TimerTick());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TimerTick()
    {
        while (GameVariables.currentTime > 0)
        {
            // attendre une seconde
            yield return new WaitForSeconds(1);
            GameVariables.currentTime--;
            timerText.text = "Time : " + GameVariables.currentTime.ToString();
        }
        // game over
        SceneManager.LoadScene("Terrain");
    }
}
