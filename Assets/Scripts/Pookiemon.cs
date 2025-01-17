using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class StatMap : SerializableDictionary<Stats, int> { }
public class StatRaiseMap : SerializableDictionary<Stats, float> { }
public enum Stats
{
    HP,
    ATTACK,
    DEFENSE,
    SPATTACK,
    SPDEFENSE,
    SPEED
}

public enum Types
{
    Normal, Fire, Water, Grass, Electric, Ice, Fighting, Poison, Ground,
    Flying, Psychic, Bug, Rock, Ghost, Dragon, Dark, Steel, Fairy, NULL
}


public class Pookiemon : MonoBehaviour
{
    private static readonly float[,] typeChart = {
    // Normal   Fire    Water   Grass   Electric  Ice    Fighting Poison  Ground  Flying  Psychic Bug    Rock    Ghost   Dragon  Dark    Steel   Fairy
    { 1f,      1f,     1f,     1f,     1f,       1f,    1f,      1f,     1f,     1f,     1f,     1f,     0.5f,  0f,     1f,     1f,     0.5f,  1f }, // Normal
    { 1f,      0.5f,   0.5f,   2f,     1f,       2f,    1f,      1f,     1f,     1f,     1f,     2f,     0.5f,  1f,     0.5f,   1f,     2f,    1f }, // Fire
    { 1f,      2f,     0.5f,   0.5f,   1f,       1f,    1f,      1f,     2f,     1f,     1f,     1f,     2f,    1f,     0.5f,   1f,     1f,    1f }, // Water
    { 1f,      0.5f,   2f,     0.5f,   1f,       1f,    1f,      0.5f,   2f,     0.5f,   1f,     0.5f,   2f,    1f,     0.5f,   1f,     0.5f,  1f }, // Grass
    { 1f,      1f,     1f,     0.5f,   0.5f,     1f,    1f,      1f,     2f,     1f,     1f,     1f,     1f,    1f,     0.5f,   1f,     1f,    1f }, // Electric
    { 1f,      0.5f,   0.5f,   2f,     1f,       0.5f,  1f,      1f,     1f,     2f,     1f,     1f,     1f,    1f,     2f,     1f,     0.5f,  1f }, // Ice
    { 2f,      1f,     1f,     1f,     1f,       2f,    1f,      0.5f,   1f,     0.5f,   0.5f,   0.5f,   2f,    0f,     1f,     2f,     2f,    0.5f }, // Fighting
    { 1f,      1f,     1f,     2f,     1f,       1f,    1f,      0.5f,   0.5f,   1f,     1f,     1f,     0.5f,  0.5f,   1f,     1f,     0f,    2f }, // Poison
    { 1f,      2f,     1f,     0.5f,   0f,       1f,    1f,      2f,     1f,     0f,     1f,     0.5f,   2f,    1f,     1f,     1f,     2f,    1f }, // Ground
    { 1f,      1f,     1f,     2f,     1f,       1f,    2f,      1f,     1f,     1f,     1f,     2f,     0.5f,  1f,     1f,     1f,     0.5f,  1f }, // Flying
    { 1f,      1f,     1f,     1f,     1f,       1f,    2f,      2f,     1f,     1f,     0.5f,   1f,     1f,    1f,     1f,     0f,     0.5f,  1f }, // Psychic
    { 1f,      0.5f,   1f,     2f,     1f,       1f,    0.5f,    0.5f,   1f,     0.5f,   1f,     1f,     1f,    0.5f,   1f,     1f,     0.5f,  0.5f }, // Bug
    { 1f,      2f,     1f,     1f,     1f,       2f,    0.5f,    1f,     0.5f,   2f,     1f,     1f,     1f,    1f,     1f,     1f,     0.5f,  1f }, // Rock
    { 0f,      1f,     1f,     1f,     1f,       1f,    1f,      1f,     1f,     1f,     2f,     1f,     1f,    2f,     1f,     0.5f,   1f,    1f }, // Ghost
    { 1f,      1f,     1f,     1f,     1f,       1f,    1f,      1f,     1f,     1f,     1f,     1f,     1f,    1f,     2f,     1f,     0.5f,  0f }, // Dragon
    { 1f,      1f,     1f,     1f,     1f,       1f,    0.5f,    1f,     1f,     1f,     2f,     1f,     1f,    2f,     1f,     0.5f,   1f,    0.5f }, // Dark
    { 1f,      0.5f,   0.5f,   1f,     1f,       2f,    1f,      1f,     1f,     1f,     1f,     1f,     2f,    1f,     1f,     1f,     0.5f,  2f }, // Steel
    { 1f,      0.5f,   1f,     1f,     1f,       1f,    2f,      0.5f,   1f,     1f,     1f,     1f,     1f,    1f,     2f,     2f,     0.5f,  1f }  // Fairy
};



    [SerializeField] StatMap baseStats;
    StatMap stats = new StatMap();
    [SerializeField] StatRaiseMap statRaises;
    static int LEVEL = 50;
    [SerializeField] Types type1;
    [SerializeField] Types type2;
    [SerializeField] List<Move> moves;

    private int currentHealth;

    public static float GetMultiplier(Types attackType, Types defend1, Types defender2)
    {
        // Base multiplier for the first type
        float multiplier = typeChart[(int)attackType, (int)defend1];

        // Apply second type multiplier if present
        if (defender2 != Types.NULL)
        {
            multiplier *= typeChart[(int)attackType, (int)defender2];
        }

        return multiplier;
    }

    public int GetStat(Stats stat)
    {
        return stats[stat];
    }


    private void Awake()
    {
        ResetChanges();
        foreach(Stats s in baseStats.Keys)
        {
            stats[s] = LEVEL * ((baseStats[s] / 50) + 5);
        }
        currentHealth = baseStats[Stats.HP];

    }

    protected void ResetChanges()
    {
        for (int i = 0; i < 6; i++)
        {
            statRaises[i] = 1;
        }
    }

    public int TakePhysicalDamage(Pookiemon attacker, Attack attack)
    {
        //Super Effectiveness
        float multiplier = GetMultiplier(attack.type, type1, type2);
        //STAB
        if(attack.type == type1 || attack.type == type2) { multiplier *= 1.5f; }
        int damage = (int)(multiplier * (2*LEVEL/5 +2) * attack.POWER * stats[Stats.ATTACK] / attacker.stats[Stats.DEFENSE]);
        currentHealth -= damage;
        return damage;
    }

    public int TakeSpecialDamage(Pookiemon attacker, Attack attack)
    {
        //Super Effectiveness
        float multiplier = GetMultiplier(attack.type, type1, type2);
        //STAB
        if (attack.type == type1 || attack.type == type2) { multiplier *= 1.5f; }
        int damage = (int)(multiplier * (2 * LEVEL / 5 + 2) * attack.POWER * stats[Stats.SPATTACK] / attacker.stats[Stats.SPDEFENSE]);
        currentHealth -= damage;
        return damage;
    }
}
