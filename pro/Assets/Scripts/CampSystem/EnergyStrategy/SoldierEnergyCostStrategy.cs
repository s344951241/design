using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierEnergyCostStrategy : IEnergyStrategy
{
    public override int GetCampUpGradeCost(int lv, SoldierType sType)
    {
        int energy = 0;
        switch (sType)
        {
            case SoldierType.Rookie:
                energy = 60;
                break;
            case SoldierType.Sergeant:
                energy = 65;
                break;
            case SoldierType.Captain:
                energy = 70;
                break;
            default:
                break;
        }
        energy += (lv - 1) * 2;
        if (energy > 100)
            energy = 100;
        return energy;
    }

    public override int GetSoldierTrainCost(SoldierType sType,int lv)
    {
        int energy = 0;
        switch (sType)
        {
            case SoldierType.Rookie:
                energy = 10;
                break;
            case SoldierType.Sergeant:
                energy = 15;
                break;
            case SoldierType.Captain:
                energy = 20;
                break;
            default:
                break;
        }
        energy += (lv - 1) * 2;
        return energy;
    }

    public override int GetWeaponUpGradeCost(WeaponType wType)
    {
        int energy = 0;
        switch (wType)
        {
            case WeaponType.Gun:
                energy = 30;
                break;
            case WeaponType.Rifle:
                energy = 40;
                break;
        }
        return energy;
    }
}
