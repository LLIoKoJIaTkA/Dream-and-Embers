using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] protected Image healthBar;
    [SerializeField] private InfoHero hero;
    [SerializeField] private TextHP healthText;

    void Awake()
    {
        healthText = GetComponent<TextHP>();
        healthBar = GetComponent<Image>();
        hero = FindObjectOfType<InfoHero>();        
    }

    private void UpdateBar() // прикрепить  к атаке врагов
    {
        healthBar.fillAmount = hero.healthPoints / hero.maxHP; //отдельным методом при получении урона
        healthText.UpdateText();
    }
}
