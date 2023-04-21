using UnityEngine;

public class BlacksmithScript : MonoBehaviour
{
    [SerializeField] GameObject IterationWindow;

    private bool _IsWorkActive;

    private void Start()
    {
        IterationWindow.SetActive(false);    
    }

    private void OnTriggerStay2D()
    {
        _IsWorkActive = true;
        if (Input.GetKey(KeyCode.E))
        {
            IterationWindow.SetActive(true);
            Time.timeScale = 0;     //freeze time, when hero use blacksmith menu
        }    
    }

    void Update()
    {
        if (_IsWorkActive)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                IterationWindow.SetActive(false);
                _IsWorkActive = false;
                Time.timeScale = 1;     //unfreeze time, when hero use blacksmith menu
            }
        }
    }

    
}