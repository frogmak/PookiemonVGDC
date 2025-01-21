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
    [Range(0,100)]public int critChance;

    public int POWER { get { return power; } }

    public override bool UseMove(Pookiemon target)
    {
        bool occured = base.UseMove(target);

        if(!occured)
        {
            return false;
        }

        int damageDealt = 0;

        if (damageType == AttackType.Physical)
        {
            damageDealt = target.TakePhysicalDamage(user, this);
        }
        else
        {
            damageDealt = target.TakeSpecialDamage(user, this);
        }
        ExtraEffects(target, damageDealt);
        return true;
    }

    //Override this method!
    protected virtual void ExtraEffects(Pookiemon target, int damageDealt)
    {

    }
}
