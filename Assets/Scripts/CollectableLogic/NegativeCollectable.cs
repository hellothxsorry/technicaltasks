using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NegativeCollectable : MonoBehaviour
{
    private UIManager _uiManager;
    [SerializeField]
    private AudioClip _wrongbeep;

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
                if (raycastHit.collider.CompareTag("Red"))
                {
                    _uiManager.Score -= 1;
                    Vibration.Vibrate(200);
                    AudioSource.PlayClipAtPoint(_wrongbeep, Camera.main.transform.position, 0.4f);
                    _uiManager.UpdateScore();                    
                    Destroy(this.gameObject);
                }
            }
        }
    }

    private void OnMouseDown()
    {
        _uiManager.Score -= 1;
        Vibration.Vibrate(200);
        AudioSource.PlayClipAtPoint(_wrongbeep, Camera.main.transform.position, 1f);
        _uiManager.UpdateScore();
        Destroy(this.gameObject);
    }
}
