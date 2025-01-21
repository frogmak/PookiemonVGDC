using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class BattleSim : MonoBehaviour
{
    [SerializeField] private List<Pookiemon> teamOne;
    [SerializeField] private List<Pookiemon> teamTwo;

    private Pookiemon playerOneActive;
    private Pookiemon playerTwoActive;

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
        
    }

    private void FieldEffect() // evaluates every on field affect
    {

    }

    private void EndBattle()
    {
        battleHasEnded = true;
    }

}
