using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    [SerializeField] string moveName;
    [SerializeField] [Range(0,100)] int accuracy;
    [SerializeField] protected Pookiemon user;
    public Types type;
    public int movePP;
    protected int currentPP;
    public int priority;

    private void Awake()
    {
        currentPP = movePP;
    }

    //Returns if move worked or not
    public virtual bool UseMove(Pookiemon target) {
        currentPP--;
        if(currentPP < 0)
        {
            return false;
        }
        if(!AttemptMove()) { return false; }
        return true;
    }

    private bool AttemptMove()
    {
        int roll = UnityEngine.Random.Range(0,100);
        return (roll * user.GetAccuracy() < accuracy);
    }

}
