using MainScripts.Stats;
using UnityEngine;
using UnityEngine.UI;

namespace MainScripts.HealthBar
{
    public class TextHP : MonoBehaviour
    {
        [SerializeField] private HeroStats hero;
        [SerializeField] private Text textHP;

        void Start()
        {
            textHP = GetComponent<Text>();
            textHP.color = Color.white;
            hero = FindObjectOfType<HeroStats>();
        }

        public void UpdateText()
        {
            textHP.text = $"{hero.healthPoints}/{hero.maxHealthPoints}";
        }
    }
}