using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AttackType
{
    Physical,
    Special
}

public class Attack : Move
{
    //Physical or special
    [SerializeField] private AttackType damageType;
    //Moves base damage amount
    [SerializeField] protected int power;

    public int POWER { get { return power; } }

    public override bool UseMove(Pookiemon target)
    {
        bool occured = base.UseMove(target);

        if(!occured)
        {
            return false;
        }

        if(damageType == AttackType.Physical)
        {
            target.TakePhysicalDamage(user, this);
        }
        else
        {
            target.TakeSpecialDamage(user, this);
        }
        ExtraEffects(target);
        return true;
    }

    //Override this method!
    protected virtual void ExtraEffects(Pookiemon target)
    {

    }
}
