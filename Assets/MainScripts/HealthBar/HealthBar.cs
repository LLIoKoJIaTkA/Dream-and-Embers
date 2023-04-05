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

    private void UpdateBar() // ����������  � ����� ������
    {
        healthBar.fillAmount = hero.healthPoints / hero.maxHP; //��������� ������� ��� ��������� �����
        healthText.UpdateText();
    }
}
