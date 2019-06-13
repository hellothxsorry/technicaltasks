using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositiveCollectable : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField]
    private AudioClip _bubblepop;

    private void Start()
    {
        _uiManager = GameObject.Find("Canvas").GetComponent<UIManager>();
    }

    private void Update()
    {
        MobileTouchScreenInput();
    }

    void MobileTouchScreenInput()
    {
        if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Began))
        {
            Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))
            {
                Debug.Log("The positive spot hit!");
                if (raycastHit.collider.CompareTag("Blue"))
                {
                    _uiManager.Score += 1;
                    _uiManager.UpdateScore();
                    AudioSource.PlayClipAtPoint(_bubblepop, Camera.main.transform.position, 3f);
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        _uiManager.Score += 1;
        _uiManager.UpdateScore();
        AudioSource.PlayClipAtPoint(_bubblepop, Camera.main.transform.position, 1f);
        Destroy(this.gameObject);
    }    
}
