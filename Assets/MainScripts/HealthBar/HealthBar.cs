using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image healthBar;
    [SerializeField] private InfoHero hero;

    void Awake()
    {
        healthBar = GetComponent<Image>();
        hero = FindObjectOfType<InfoHero>();
        healthBar.fillAmount = hero.healthPoints / hero.maxHP;
    }


    private void UpdateBar()
    {
        healthBar.fillAmount = hero.healthPoints / hero.maxHP; //отдельным методом при получении урона
    }
}
