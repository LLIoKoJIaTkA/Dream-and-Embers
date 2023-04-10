using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlacksmithScript : MonoBehaviour
{
    [SerializeField] GameObject IterationWindow;

    private bool workIsActive;

    void Start()
    {
        IterationWindow.SetActive(false);    
    }

    private void OnTriggerStay2D()
    {
        workIsActive = true;
        if(Input.GetKey(KeyCode.F))
        {
            IterationWindow.SetActive(true);
            Time.timeScale = 0;     //freeze time, when hero use blacksmith menu
        }
        
    }

    private void Update()
    {
        if(workIsActive == true)
        {
            if(Input.GetKey(KeyCode.Escape))
            {
                IterationWindow.SetActive(false);
                workIsActive = false;
                Time.timeScale = 1;     //unfreeze time, when hero use blacksmith menu
            }
        }
    }
}