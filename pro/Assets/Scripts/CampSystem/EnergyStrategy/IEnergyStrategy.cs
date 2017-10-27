using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//能量升级策略
public abstract class IEnergyStrategy{

    public abstract int GetCampUpGradeCost(int lv, SoldierType sType);
    public abstract int GetWeaponUpGradeCost(WeaponType wType);
    public abstract int GetSoldierTrainCost(SoldierType sType,int lv);
}
