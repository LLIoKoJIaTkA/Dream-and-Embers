using MainScripts.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace MainScripts.HealthBar
{
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image healthBar;
        [SerializeField] private HeroStats hero;
        private TextHP healthText;

        void Awake()
        {
            healthBar = GetComponent<Image>();
            healthText = FindObjectOfType<TextHP>();
            hero = FindObjectOfType<HeroStats>();            
        }

        private void Start()
        {
            UpdateBar();
        }

        private void UpdateBar()
        {
            healthBar.fillAmount = hero.healthPoints / hero.maxHealthPoints;
            healthText.UpdateText();
        }
    }
}