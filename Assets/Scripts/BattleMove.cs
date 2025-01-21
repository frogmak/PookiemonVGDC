using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// for when a pookiemon uses a move (both hits and misses)
public class BattleMove : BattleAction
{
    private bool isHit;
    public bool IsHit { get { return isHit; } }
    private Move move;

    public virtual void SetAction(Player _active, Player _target, Move _move)
    {
        activePlayer = _active;
        targetPlayer = _target;
        move = _move;
    }

    public override void ApplyAction()
    {
        if (isHit)
        {
            narrationLine = $"{activePlayer.Pookiemon.pookiemonName} used {move.moveName} on {targetPlayer.Pookiemon.pookiemonName}.";
            move.UseMove(targetPlayer.Pookiemon);
        }
        else
        {
            narrationLine = $"{activePlayer.Pookiemon.pookiemonName} missed.";
        }
    }
}
