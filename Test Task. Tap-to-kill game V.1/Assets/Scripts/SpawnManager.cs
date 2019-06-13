using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    private GameManager _gameManager;
    [SerializeField]
    private bool _isRunning = false;

    [SerializeField]
    private float _positiveCollectableSpawnTime = 1f;
    [SerializeField]
    private float _negativeCollectableSpawnTime = 2f;    
    [SerializeField]
    private GameObject _positiveCollectable;
    [SerializeField]
    private GameObject _negativeCollectable;    

    void Start()
    {
        _gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        StartCoroutine(PositiveSpawnRoutine());
        StartCoroutine(NegativeSpawnRoutine());
    }
    
    void Update()
    {
        if (_gameManager.timerText.text == "40" || _gameManager.timerText.text == "20")
        {
            if (_isRunning == false)
            {
                _isRunning = true;
                StartCoroutine(PositiveSpawnRoutine());                
                StartCoroutine(NegativeSpawnRoutine());                
                Debug.Log("2d and 3d coroutines have been started");
            }            
        }
        else if (_gameManager.timerText.text == "35")
        {
            _isRunning = false;
            Debug.Log("ready for the next coroutine");
        }
    }

    public IEnumerator PositiveSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(_positiveCollectable, new Vector3(Random.Range(-17f, 17f), Random.Range(-9f, 6.5f), 0), Quaternion.identity);
            yield return new WaitForSeconds(_positiveCollectableSpawnTime); 
        }
    }

    public IEnumerator NegativeSpawnRoutine()
    {
        while (_gameManager.gameOver == false)
        {
            Instantiate(_negativeCollectable, new Vector3(Random.Range(-17f, 17f), Random.Range(-9f, 6.5f), 0), Quaternion.identity);
            yield return new WaitForSeconds(_negativeCollectableSpawnTime);
        }
    }
}
