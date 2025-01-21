using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [Header("Team SetUp")]
    public string playerName = "Team _";
    [SerializeField] private List<GameObject> teamGOs;

    private List<Pookiemon> team;
    public List<Pookiemon> Team { get { return team; } }
    private Pookiemon currentPookiemon;

    public Pookiemon Pookiemon { get { return currentPookiemon; } }
    [SerializeField] private Transform battleStation;

    [Header("UI")]
    [SerializeField] private HealthUI healthUI;

    public BattleAction currentMove;

    private void Awake()
    {
        team = new List<Pookiemon>();
    }

    public void InitPlayer()
    {
        foreach (GameObject pookie in teamGOs)
        {
            Pookiemon pookiemon = Instantiate(pookie, battleStation).GetComponent<Pookiemon>();
            team.Add(pookiemon);
            pookiemon.gameObject.SetActive(false);
        }

        currentPookiemon = team[0];
        healthUI.Init(currentPookiemon);
    }

    // switch pookie method here

    public void SwitchPookie(Pookiemon pookiemon)
    {
        currentPookiemon.gameObject.SetActive(false);
        currentPookiemon = pookiemon;
        currentPookiemon.gameObject.SetActive(true);
    }
}
