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
    public HealthUI HealthUi {  get { return healthUI; } }

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
            pookiemon.Init();
            team.Add(pookiemon);
            pookiemon.gameObject.SetActive(false);
        }

        currentPookiemon = team[0];
        currentPookiemon.gameObject.SetActive(true);
        healthUI.Init(currentPookiemon);
    }

    public void SwitchPookie(Pookiemon pookiemon = null)
    {
        currentPookiemon.gameObject.SetActive(false);

        // if no pookiemon is provided, then find a random
        if (pookiemon == null)
        {
            List<Pookiemon> livePookiemon = GetLivePookiemon();
            if (livePookiemon.Count > 1)
            {
                Pookiemon newPookiemon = currentPookiemon;
                while (newPookiemon == currentPookiemon)
                {
                    newPookiemon = livePookiemon[Random.Range(0, livePookiemon.Count)];
                }
                currentPookiemon = newPookiemon;
            }
        }
        else
        {
            currentPookiemon = pookiemon;
        }

        currentPookiemon.gameObject.SetActive(true);
    }

    private List<Pookiemon> GetLivePookiemon()
    {
        List<Pookiemon> livePookiemon = new List<Pookiemon>();
        foreach (Pookiemon pookie in team)
        {
            if (!pookie.IsDead)
                livePookiemon.Add(pookie);
        }
        return livePookiemon;
    }
}
