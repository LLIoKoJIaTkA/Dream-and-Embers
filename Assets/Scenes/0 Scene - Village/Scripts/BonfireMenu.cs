using UnityEngine;

public class BonfireMenu : MonoBehaviour
{
    [SerializeField] GameObject BonfireWindow;

        private bool _IsBonfire;

    private void Start()
    {
        BonfireWindow.SetActive(false); 
    }

    private void OnTriggerStay2D()
    {
        _IsBonfire = true;
        if (Input.GetKey(KeyCode.E))
        {
            BonfireWindow.SetActive(true);
            Time.timeScale = 0;     //freeze time, when hero use bonfire menu
        }    
    }

    void Update()
    {
        if (_IsBonfire)
        {
            if (Input.GetKey(KeyCode.Escape))
            {
                BonfireWindow.SetActive(false);
                _IsBonfire = false;
                Time.timeScale = 1;     //unfreeze time, when hero use bonfire menu
            }
        }
    }
}
