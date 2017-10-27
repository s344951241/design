using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierCamp : ICamp {

    const int MAX_LV = 4;
    private int mLv = 1;
    private WeaponType mWeaponType = WeaponType.Gun;

    public SoldierCamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 pos,float trainTime, WeaponType weaponType = WeaponType.Gun, int lv = 1) : base(gameObject, name, icon, soldierType, pos,trainTime)
    {
        mLv = lv;
        mWeaponType = weaponType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
        UpdateEnergyCost();
    }

    public override int EnergyCostCampUpGrade
    {
        get
        {
            if (mLv == MAX_LV)
                return -1;
            else
                return mEnergyCostCampUpGrade;
        }
    }

    public override int EnergyCostTrain
    {
        get
        {
            return mEnergyCostTrain;
        }
    }

    public override int EnergyCostWeaponUpGrade
    {
        get
        {
            if (mWeaponType + 1 == WeaponType.MAX)
            {
                return -1;
            }
            else
                return mEnergyCostWeaponUpGrade;
        }
    }

    public override int Lv
    {
        get
        {
            return mLv;
        }
    }

    public override WeaponType WeaponType
    {
        get
        {
            return mWeaponType;
        }
    }

    public override void Train()
    {
        TrainSoldierCommand cmd = new TrainSoldierCommand(mSoldierType, mWeaponType, mPosition, mLv);
        mCommands.Add(cmd);
    }
    protected override void UpdateEnergyCost()
    {
        mEnergyCostCampUpGrade = mEnergyCostStrategy.GetCampUpGradeCost( mLv, mSoldierType);
        mEnergyCostWeaponUpGrade = mEnergyCostStrategy.GetWeaponUpGradeCost(mWeaponType);
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, mLv);

    }

    public override void UpGradeCamp()
    {
        //TODO
        mLv++;
        UpdateEnergyCost();
    }

    public override void UpWeaponGrade()
    {
        //TODO
        mWeaponType = mWeaponType + 1;
        UpdateEnergyCost();
    }
}
