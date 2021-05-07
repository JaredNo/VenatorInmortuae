using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class BossStats
{
    public static int health;

    public static int phase;

    public static void ModifyHealth(int i)
    {
        health = health + i;
    }
}
