using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class UIBehaviour : MonoBehaviour
{
    TMP_Text headText;
    TMP_Text timerText;
    TMP_Text levelText;
    int nbHeads = 0;

    private AudioSource aud_end;
    public GameObject fx_end;

    private IEnumerator timer_coroutine;



    void Start()
    {
        GameVariables.currentTime = GameVariables.allowedTime;
        aud_end = GameObject.Find("AudioWin").GetComponent<AudioSource>();
        headText = GameObject.Find("lb_bob").GetComponent<TMPro.TMP_Text>();
        timerText = GameObject.Find("timer").GetComponent<TMPro.TMP_Text>();
        levelText = GameObject.Find("level").GetComponent<TMPro.TMP_Text>();

        headText.text = "BobHeads : " + nbHeads + "/" + randomBob.nbObjects;
        levelText.text = "Level " + randomBob.nbObjects;
        timerText.text = "Time : " + GameVariables.currentTime.ToString();

        StartCoroutine((timer_coroutine = TimerTick()));
    }
    void Update()
    {
        if (nbHeads == randomBob.nbObjects)
        {
            nbHeads = 0;
            randomBob.nbObjects++;
            headText.text = " WIN !";

            Vector3 t_bis = transform.position;
            Vector3 t_ter = transform.position;
            t_bis.x += 4;
            t_ter.x -= 4;

            Instantiate(fx_end, transform.position, Quaternion.Euler(-90, 0, 0));
            Instantiate(fx_end, t_bis, Quaternion.Euler(-90, 0, 0));
            Instantiate(fx_end, t_ter, Quaternion.Euler(-90, 0, 0));
            if (aud_end)
            {
                aud_end.Play();
            }

            StartCoroutine(resetGameCoroutine());
            StopCoroutine(timer_coroutine);

            //teleport player
            GameObject player = GameObject.FindWithTag("Player");
            if (player)
            {
                Vector3 pos = this.transform.position;
                pos.y = 0;
                player.transform.position = pos;
                player.transform.rotation = Quaternion.Euler(0, 90, 0);
            }
        }
        
    }
    IEnumerator resetGameCoroutine()
    {
        yield return new WaitForSeconds(15.0f);
        aud_end.Stop();
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void AddHit()
    {
        nbHeads++;
        headText.text = "BobHeads : " + nbHeads + "/" + randomBob.nbObjects;
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
        SceneManager.LoadScene("stage"); 
    }
}