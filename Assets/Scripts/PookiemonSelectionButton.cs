using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PookiemonSelectionButton : MonoBehaviour
{
    private const string levelLabel = "Lv.";

    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text levelText;
    [SerializeField] private Slider healthbar;
    [SerializeField] private TMP_Text healthText;
    [SerializeField] private Image image;

    [SerializeField] private Button myButton;
    private Pookiemon pookiemon;

    private void Awake()
    {
        myButton.onClick.AddListener(OnClick);
    }

    public void Init(Pookiemon pookie)
    {
        pookiemon = pookie;
        nameText.text = pookie.pookiemonName;
        levelText.text = $"{levelLabel}{Pookiemon.LEVEL}";

        healthbar.maxValue = pookie.GetStat(Stats.HP);
        healthbar.minValue = 0;
        healthbar.value = pookie.CurrentHealth;

        healthText.text = $"{healthbar.value}/{healthbar.maxValue}";

        image.sprite = pookie.sprite;
    }

    private void OnClick()
    {
        // choose the pookiemon here
    }
}
