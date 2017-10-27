﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageSystem : IGameSystem
{
    private int mLv = 1;
    List<Vector3> mPosList;
    IStageHandler mRootHandler;
    public override void Init()
    {
        base.Init();
        InitSpawnPosition();
        InitStageChain();
    }

    public override void Update()
    {
        base.Update();
        mRootHandler.Handle(mLv);
        
    }
    private void InitStageChain()
    {
        int lv = 1;
        NormalStageHandler handler1 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Gun,3,GetRandomPos(),3);
        NormalStageHandler handler2 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Rifle, 3, GetRandomPos(), 6);
        NormalStageHandler handler3 = new NormalStageHandler(this, lv++, EnemyType.Elf, WeaponType.Rocket,3, GetRandomPos(), 9);
        NormalStageHandler handler4 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Gun, 4, GetRandomPos(), 14);
        NormalStageHandler handler5 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rifle, 4, GetRandomPos(), 18);
        NormalStageHandler handler6 = new NormalStageHandler(this, lv++, EnemyType.Ogre, WeaponType.Rocket, 4, GetRandomPos(), 22);
        NormalStageHandler handler7 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Gun, 5, GetRandomPos(),27);
        NormalStageHandler handler8 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rifle, 5, GetRandomPos(), 32);
        NormalStageHandler handler9 = new NormalStageHandler(this, lv++, EnemyType.Troll, WeaponType.Rocket, 5, GetRandomPos(), 37);

        handler1.SetNextHandler(handler2)
            .SetNextHandler(handler3)
            .SetNextHandler(handler4)
            .SetNextHandler(handler5)
            .SetNextHandler(handler6)
            .SetNextHandler(handler7)
            .SetNextHandler(handler8)
            .SetNextHandler(handler9);
        mRootHandler = handler1;
    }
    private void InitSpawnPosition()
    {
        mPosList = new List<Vector3>();
        int i = 1;
        while (true)
        {
           GameObject GO = GameObject.Find("Position" + i);
            if (GO != null)
            {
                mPosList.Add(GO.transform.position);
                GO.SetActive(false);
            }
            else
            {
                break;
            }
        }
    }
    private Vector3 GetRandomPos()
    {
        return mPosList[UnityEngine.Random.Range(0, mPosList.Count)];
    }
    public int GetCountOfEnemyKilled()
    {
        return 0;//TODO
    }
    public void EnterNextStage()
    {
        //TODO
    }
}
