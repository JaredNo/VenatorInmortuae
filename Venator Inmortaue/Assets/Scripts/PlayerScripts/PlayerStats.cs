using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerStats
{
    public static int health;
    public static int ammo;
    public static float[] PlayerPos = new float[3];

    public static bool CanShoot = true;

    public static void ModifyHealth(int damage)
    {
        if(health > 0)
        {
            health = health + damage;
        }
    }

    public static void ModifyAmmo(int Modifier)
    {
        ammo = ammo + Modifier;
    }
}
