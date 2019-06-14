using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Text scoreText;
    public int Score;
    public GameObject titleScreen;
    public Text gameOverText;
    public Text finalScore;
    public GameObject _pauseMenu;
    public GameObject PauseButton;
    public GameObject StartButton;
    public GameObject RestartButton;
    private GameManager _gameManager;
    private Coroutine PositiveSpawnRoutine;
    private Coroutine NegativeSpawnRoutine;
    private SpawnManager _spawnManager;    
    private Animator _pauseMenuAnimator;

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        _spawnManager = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        _pauseMenuAnimator = GameObject.Find("Pause_Menu").GetComponent<Animator>();
        _pauseMenuAnimator.updateMode = AnimatorUpdateMode.UnscaledTime;
        
        Time.timeScale = 0;
        titleScreen.SetActive(true);
        scoreText.enabled = false;
        finalScore.enabled = false;
        gameOverText.enabled = false;
        PauseButton.SetActive(false);
    }

    void Update()
    {
        if (Score < 0)
        {
            Score = 0;
            scoreText.text = "Score: 0";
        }

        if (_gameManager.gameOver == true && PositiveSpawnRoutine != null && NegativeSpawnRoutine != null)
        {            
            StopCoroutine(PositiveSpawnRoutine);
            PositiveSpawnRoutine = null;
            StopCoroutine(NegativeSpawnRoutine);
            NegativeSpawnRoutine = null;
        }
    }

    public void UpdateScore()
    {
        scoreText.text = "Score: " + Score; 
    }

    public void FinalScore()
    {
        finalScore.enabled = true;
        finalScore.text = "YOUR FINAL SCORE: " + Score + "!";
    }

    public void ButtonClicked()
    {
        if (_gameManager.gameOver == true && PositiveSpawnRoutine == null && NegativeSpawnRoutine == null)
        {
            StartButton.SetActive(false);
            RestartButton.SetActive(true);
            
            Time.timeScale = 1;
            _gameManager.countDownTimer = 60f;
            _gameManager.gameOver = false;
            titleScreen.SetActive(false);
            gameOverText.enabled = false;
            scoreText.enabled = true;
            Score = 0;
            scoreText.text = "Score: " + Score;
            finalScore.enabled = false;
            PauseButton.SetActive(true);
            _gameManager.timerText.enabled = true;
            PositiveSpawnRoutine = StartCoroutine(_spawnManager.PositiveSpawnRoutine());
            NegativeSpawnRoutine = StartCoroutine(_spawnManager.NegativeSpawnRoutine());
        }        
    }

    public void PauseClicked()
    {        
        _pauseMenu.SetActive(true);
        _pauseMenuAnimator.SetBool("isPaused", true);        
        PauseButton.SetActive(false);
        Time.timeScale = 0;
        AudioListener.pause = true;
    }

    public void ResumeGame()
    {
        _pauseMenu.SetActive(false);
        PauseButton.SetActive(true);
        Time.timeScale = 1;
        AudioListener.pause = false;
    }
}
