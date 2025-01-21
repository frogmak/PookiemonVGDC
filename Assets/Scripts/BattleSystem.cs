using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum BattleState { START, P1TURN, P2TURN, BATTLE}

public class BattleSystem : MonoBehaviour
{
    public static BattleSystem instance;

    [Header("Player Configurations")]
    [SerializeField] Player player1;
    [SerializeField] Player player2;
    private Player currentPlayer;

    [Header("UI")]
    [SerializeField] private PlayerHUD playerHUD;

    [Header("Timing Configurations")]
    // timing parameters
    [SerializeField] private float setUpBattleTime = 2f;
    [SerializeField] private float startBattleTime = 2f;

    private BattleState currentState;
    private Queue<string> battleNarration;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
        }
    }

    private void Start()
    {
        currentState = BattleState.START;

        StartCoroutine(SetupBattle());
    }

    private IEnumerator SetupBattle()
    {
        // spawn all pookiemon at their respective battle positions and turn them all off
        player1.InitPlayer();
        player2.InitPlayer();

        playerHUD.ShowNarration("Let the Pookiemon battle begin!", true);

        yield return new WaitForSeconds(setUpBattleTime);

        currentState = BattleState.START;
        NextPhase();
    }

    private void Player1Turn()
    {
        playerHUD.ShowActionPrompt($"What will {player1.Pookiemon.pookiemonName.ToUpper()} do?");
    }

    private void Player2Turn()
    {
        playerHUD.ShowActionPrompt($"What will {player1.Pookiemon.pookiemonName.ToUpper()} do?");
    }

    // sort the move order queue and determine outcomes (calculate things that need to be caclulated) 
    private void SetUpBattle()
    {

    }

    private void BeginBattle()
    {
        // play things out here in elaborate coroutines
    }

    private void NextPhase()
    {
        switch (currentState)
        {
            case BattleState.START:
                currentState = BattleState.P1TURN;
                currentPlayer = player1;
                Player1Turn();
                break;
            case BattleState.P1TURN:
                currentState = BattleState.P2TURN;
                currentPlayer = player2;
                Player2Turn();
                break;
            case BattleState.P2TURN:
                currentPlayer = null;
                currentState = BattleState.BATTLE;
                break;
            case BattleState.BATTLE:
                currentPlayer = null;
                currentState = BattleState.P1TURN;
                break;
        }
    }

    // called after the battle is over
    private void CheckGameOver()
    {
        bool teamOneDead = CheckTeamIsDead(player1.Team);
        bool teamTwoDead = CheckTeamIsDead(player2.Team);

        if (teamOneDead && teamTwoDead) // tie state
        {
            playerHUD.ShowNarration("All Pookiemon have fainted. It's a tie!");
        }
        else if (teamOneDead)
        {
            playerHUD.ShowNarration("Player 1 defeated. Player 2 wins!");
        }
        else if (teamTwoDead)
        {
            playerHUD.ShowNarration("Player 2 defeated. Player 1 wins!");
        }
    }

    // checks a players team to see if it is completely knocked out
    private bool CheckTeamIsDead(List<Pookiemon> playerTeam)
    {
        foreach (Pookiemon p in playerTeam)
        {
            if (!p.IsDead)
                return false;
        }

        return true;
    }

    #region Action Prompt Buttons
    public void OnRun()
    {
        playerHUD.ShowActionPrompt("Can't run, bozo!");
    }

    public void OnBag()
    {
        playerHUD.ShowActionPrompt("You a broke af!");
    }

    public void OnFight()
    {
        if (currentState != BattleState.P1TURN || currentState != BattleState.P2TURN)
            return;

        playerHUD.ShowFightPrompt(currentPlayer.Pookiemon);
    }

    public void OnPookiemonSelect()
    {
        if (currentState != BattleState.P1TURN || currentState != BattleState.P2TURN)
            return;

        playerHUD.ShowPookiemonSelect(currentPlayer.Team);
        // queue up the pookiemon select action
    }

    #endregion

    public void OnMoveSelected(Move move)
    {
        BattleMove action = new BattleMove();
        action.SetAction(currentPlayer, currentPlayer == player1 ? player2 : player1, move);
    }

    //Called by the switch in button
    public void OnPookiemonSwitched(Pookiemon p)
    {
        BattleSwitchAction action = new BattleSwitchAction();
        action.SetAction(currentPlayer, currentPlayer == player1 ? player2 : player1, p);
        currentPlayer.currentMove = action;
    }
}