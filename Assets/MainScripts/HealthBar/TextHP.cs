using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TextHP : MonoBehaviour
{
    [SerializeField] private InfoHero hero;
    [SerializeField] private Text textHP;

    void Start()
    {
        textHP = GetComponent<Text>();
        textHP.color = Color.white;
        hero = FindObjectOfType<InfoHero>();
    }

    public void UpdateText()
    {
        textHP.text =  hero.healthPoints <= hero.maxHP ? $"{hero.healthPoints}/{hero.maxHP}" : $"{hero.maxHP}/{hero.maxHP}"; 
    }
}
