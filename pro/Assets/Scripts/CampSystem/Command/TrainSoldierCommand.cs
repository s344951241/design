using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainSoldierCommand : ITrainCommand
{
    SoldierType mSoldierType;
    WeaponType mWeaponType;
    Vector3 mpos;
    int mLv;

    public TrainSoldierCommand(SoldierType sType, WeaponType wType, Vector3 pos, int lv)
    {
        mSoldierType = sType;
        mWeaponType = wType;
        mpos = pos;
        mLv = lv;
    }

    public override void Excute()
    {
        switch (mSoldierType)
        {
            case SoldierType.Rookie:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierRookie>(mWeaponType, mpos, mLv);
                break;
            case SoldierType.Sergeant:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierSergeant>(mWeaponType, mpos, mLv);
                break;
            case SoldierType.Captain:
                FactoryManager.SoldierFactory.CreateCharacter<SoldierCaptain>(mWeaponType, mpos, mLv);
                break;
            default:
                break;
        }

    }
}
