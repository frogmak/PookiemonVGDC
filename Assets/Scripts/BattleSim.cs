using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BattleSim : MonoBehaviour
{
    [SerializeField] private List<Pookiemon> teamOne;
    [SerializeField] private List<Pookiemon> teamTwo;

    private Pookiemon playerOneActive;
    private Pookiemon playerTwoActive;

    private bool playerOneIsDead;
    private bool playerTwoIsDead;

    private int turnNumber;

    private bool battleHasEnded;

    private void Start()
    {
        Debug.Log("Starting Battle");
        battleHasEnded = false;

        StartBattle();
    }

    private void StartBattle() // assigns each player their first slot pokemon at the start of battle
    {
        playerOneActive = teamOne[0];
        playerTwoActive = teamTwo[0];

        playerOneIsDead = false;
        playerTwoIsDead = false;
    }

    private void SimulateBattle() // battle loop
    {
        while (!battleHasEnded)
        {
            PlayerMove(playerOneActive);
            PlayerMove(playerTwoActive);
            BattlePhase();
            TurnUpKeep();
        }
    }

    private void PlayerMove(Pookiemon player)
    {

    }

    private void BattlePhase()
    {

    }

    private void TurnUpKeep()
    {
        if (CheckTeamIsDead(teamOne) ||  CheckTeamIsDead(teamTwo)) // First check to see if teams are alive. End the game if not
        {
            if (playerOneIsDead)
            {
                Debug.Log("Player 2 Wins!");
            } else if (playerTwoIsDead)
            {
                Debug.Log("Player 1 Wins!");
            }
            EndBattle();
        }
        FieldEffect(); // Updates any field effects
    }

    private bool CheckTeamIsDead(List<Pookiemon> playerTeam)
    {
        foreach (Pookiemon p in playerTeam)
        {
            if (!p.IsDead)
                return false;
        }

        if (playerTeam == teamOne)
        {
            playerOneIsDead = true;
        } else
        {
            playerTwoIsDead = true;
        }

        return true;
    }

    private void FieldEffect() // evaluates every on field affect
    {

    }

    private void EndBattle()
    {
        battleHasEnded = true;
    }

}
