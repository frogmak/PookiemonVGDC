using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// just a base class
public class BattleAction
{
    protected Player activePlayer;
    protected Player targetPlayer;
    protected string narrationLine;

    public virtual void SetAction(Player _active, Player _target)
    {
        activePlayer = _active;
        targetPlayer = _target;
    }

    public virtual void ApplyAction()
    {
        Debug.Log($"Override this. {activePlayer.playerName} did something to {targetPlayer.playerName}.");
    }
}
/*
// move happens "attack lands"
    move name and stats
// player switches out pookiemon
    - "player switchedo out their Pookiemon to ____"
    - ative player's pookiemon
// player pookiemon faints
    "____ fainted."
    - ative player's pookiemon
// move fails -- soley dialogue
    - move name

ALL
- current player vs "enemy player"
*/