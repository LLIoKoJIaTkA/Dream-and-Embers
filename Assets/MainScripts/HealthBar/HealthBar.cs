using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Image healthBar;
    [SerializeField] private InfoHero hero;
    private TextHP healthText;

    void Awake()
    {
        healthText = FindFirstObjectByType<TextHP>();
        healthBar = GetComponent<Image>();
        hero = FindObjectOfType<InfoHero>();        
    }

    private void Start()
    {
        UpdateBar();
    }

    private void UpdateBar() // прикрепить  к атаке врагов
    {
        healthBar.fillAmount = hero.healthPoints / hero.maxHP; //отдельным методом при получении урона
        healthText.UpdateText();
    }
}