using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public float countDownTimer = 60f;
    public Text timerText;
    private SpawnManager _spawnManager;
    private UIManager _uiManager;

    [SerializeField]
    public bool gameOver = true;    

    void Start()
    {
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
        timerText.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        Timer();

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("MainMenu");
        }        

        if (countDownTimer == 0)
        {
            
            gameOver = true;
            _uiManager.titleScreen.SetActive(true);
            timerText.enabled = false;
            _uiManager.gameOverText.enabled = true;
            _uiManager.FinalScore();
            _uiManager.scoreText.enabled = false;
            _uiManager.PauseButton.SetActive(false);
        }
    }    

    void Timer()
    {
        countDownTimer -= Time.deltaTime;
        timerText.text = (countDownTimer).ToString("0");
        if (countDownTimer < 0)
        {
            countDownTimer = 0;
        }
    }
}
