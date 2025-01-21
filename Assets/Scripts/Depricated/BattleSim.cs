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
            TurnEndStep();
        }
    }

    private void PlayerMove(Pookiemon player) // evaluates a player's move
    {

    }

    public void OnBack() // goes back to the battle menu
    {
        //return to battle menu
    }

    public void OnRun(Pookiemon player)
    {
        Debug.Log("Can't run, bozo!");
        PlayerMove(player);
    }

    public void OnBag(Pookiemon player)
    {
        Debug.Log("You a broke af!");
        PlayerMove(player);
    }

    private void BattlePhase()
    {

    }

    private void TurnEndStep() // Events that occure after the battle phase has ended, before the start of a new turn
    {
        FieldEffect(); // Updates any field effects
        if (CheckTeamIsDead(teamOne) ||  CheckTeamIsDead(teamTwo)) // Then check to see if teams are alive. End the game if a team is dead
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
        
    }

    private bool CheckTeamIsDead(List<Pookiemon> playerTeam) // checks a players team to see if it is completely knocked out
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

    private void EndBattle() // end ab ttle
    {
        battleHasEnded = true;
    }

}
