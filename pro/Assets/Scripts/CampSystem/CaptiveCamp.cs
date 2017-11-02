using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptiveCamp : ICamp
{
    private WeaponType mWeaponType = WeaponType.Gun;
    private EnemyType mEnemyType;
    public CaptiveCamp(GameObject gameObject, string name, string icon, EnemyType eType,Vector3 pos, float trainTime) : base(gameObject, name, icon, SoldierType.Captive, pos, trainTime)
    {
        mEnemyType = eType;
        mEnergyCostStrategy = new SoldierEnergyCostStrategy();
    }

    public override int EnergyCostCampUpGrade
    {
        get
        {
            return 0;
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
            return 0;
        }
    }

    public override int Lv
    {
        get
        {
            return 1;
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
        TrainCaptiveCommand cmd = new TrainCaptiveCommand(mEnemyType, mWeaponType,mPosition);
        mCommands.Add(cmd);
    }

    public override void UpGradeCamp()
    {
        return;
    }

    public override void UpWeaponGrade()
    {
        return;
    }

    protected override void UpdateEnergyCost()
    {
        mEnergyCostTrain = mEnergyCostStrategy.GetSoldierTrainCost(mSoldierType, 1);
    }
}
