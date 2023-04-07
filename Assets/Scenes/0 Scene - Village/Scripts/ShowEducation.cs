using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowEducation : MonoBehaviour
{
    [SerializeField] GameObject EducationText;

    void Start()
    {
        EducationText.SetActive(false);    
    }

    private void OnTriggerStay2D()
    {
        EducationText.SetActive(true);
    }

    private void OnTriggerExit2D()
    {
        EducationText.SetActive(false);
    }
}