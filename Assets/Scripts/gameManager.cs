using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class gameManager : MonoBehaviour
{
    public static gameManager I;
    public GameObject square;
    public Text timeTxt;
    float alive = 0f;
    public GameObject endPanel;
    public Text thisScoreTxt;
    public Text bestScoreTxt;
    public Animator anim;
    bool isRunning = true;
    


    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
        InvokeRepeating("makeSquare", 0.0f, 0.5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning)
        {
            alive += Time.deltaTime;
            timeTxt.text = alive.ToString("N2");
        }

    }

    void makeSquare()
    {
        Instantiate(square);
    }

    public void gameOver()
    {
        anim.SetBool("isDie", true);

        isRunning = false;
        Invoke("timeStop", 0.5f);
        thisScoreTxt.text = alive.ToString("N2");
        bestScoreTxt.text = PlayerPrefs.GetFloat("bestScore").ToString("N2");
        endPanel.SetActive(true);

        if (PlayerPrefs.HasKey("bestScore") == false)
        {
            PlayerPrefs.SetFloat("bestScore", alive);
        }
        else
        {
            if (PlayerPrefs.GetFloat("bestScore") < alive)
            {
                PlayerPrefs.SetFloat("bestScore", alive);
            }
        }
    }
    void timeStop()
    {
        Time.timeScale = 0.0f;
    }
    // 싱글톤 처리하기
    void Awake()
    {
        I = this;
    }

    public void retry()
    {
        SceneManager.LoadScene("SampleScene");
    }

}
