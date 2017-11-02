using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainCaptiveCommand : ITrainCommand
{
    private EnemyType mEnemyType;
    WeaponType mWeaponType;
    Vector3 mPos;
    int mLv;
    public TrainCaptiveCommand(EnemyType eType,WeaponType wType,Vector3 pos,int lv=1)
    {
        mEnemyType = eType;
        mWeaponType = wType;
        mPos = pos;
        mLv = lv;
    }
    public override void Excute()
    {
        IEnemy enemy = null;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mPos, mLv) as IEnemy;
                break;
            case EnemyType.Ogre:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPos, mLv) as IEnemy;
                break;
            case EnemyType.Troll:
                enemy = FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPos, mLv) as IEnemy;
                break;
            default:
                break;
        }
        GameFacade.Instance.removeEnemy(enemy);
        SoldierCaptive captive = new SoldierCaptive(enemy);
        GameFacade.Instance.addSoldier(captive);
    }

}
