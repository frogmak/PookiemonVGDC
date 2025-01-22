using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class PlayerHUD : MonoBehaviour
{
    [Header("Narration")]
    [SerializeField] private GameObject narrationUI;
    [SerializeField] private TMP_Text narrationText;

    [Header("Actions")]
    [SerializeField] private GameObject actionPromptUI;
    [SerializeField] private TMP_Text actionPromptText;

    [Header("Fight")]
    [SerializeField] private GameObject fightPromptUI;
    [SerializeField] private TMP_Text pp;
    [SerializeField] private TMP_Text type;

    [Header("Pookemon Select")]
    [SerializeField] private GameObject pookiemonSelectUI;
    [SerializeField] private List<PookiemonSelectionButton> selectionButtons;

    private void Awake()
    {
        HideAll();
    }

    public void Back()
    {
        ShowActionPrompt($"What will {BattleSystem.instance.CurrentPlayer.Pookiemon.pookiemonName.ToUpper()} do?");
    }

    private void HideAll()
    {
        narrationUI.SetActive(false);
        actionPromptUI.SetActive(false);
        fightPromptUI.SetActive(false);
        pookiemonSelectUI.SetActive(false);
    }

    public void ShowNarration(string text, bool prepUI = false)
    {
        if (prepUI)
            HideAll();
        narrationUI.SetActive(true);
        narrationText.text = text;
    }

    public void ShowActionPrompt(string text)
    {
        HideAll();
        actionPromptUI.SetActive(true);
        actionPromptText.text = text;
    }

    public void ShowFightPrompt(Pookiemon pookie)
    {
        HideAll();
        fightPromptUI.SetActive(true);

        // initalize the move data somehow
    }

    public void ShowPookiemonSelect(List<Pookiemon> pookies)
    {
        for (int i = 0; i < selectionButtons.Count; i++)
        {
            selectionButtons[i].Init(pookies[i]);
        }
        HideAll();
        pookiemonSelectUI.SetActive(true);
        // do more stuff to init the selection buttons
    }
}
