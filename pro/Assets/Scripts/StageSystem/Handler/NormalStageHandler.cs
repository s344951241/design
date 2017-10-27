using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NormalStageHandler : IStageHandler {

    private EnemyType mEnemyType;
    private WeaponType mWeaponType;
    private int mCount;
    private Vector3 mPos;
    private int mSpawnTime = 1;
    private float mSpawnTimer = 0;
    private int mCountSpawned = 0;
    public NormalStageHandler(StageSystem system,int lv,EnemyType eType,WeaponType wType,int count ,Vector3 pos,int countToFinish) : base(system,lv, countToFinish)
    {
        mEnemyType = eType;
        mWeaponType = wType;
        mCount = count;
        mPos = pos;
        mSpawnTimer = mSpawnTime;
    }

    protected override void UpdateStage()
    {
        base.UpdateStage();
        if (mCountSpawned < mCount)
        {
            mSpawnTimer -= Time.deltaTime;
            if (mSpawnTimer <= 0)
            {
                SpawnEnemy();
                mSpawnTimer = mSpawnTime;
            }
        }
        
    }
    void SpawnEnemy()
    {
        mCountSpawned++;
        switch (mEnemyType)
        {
            case EnemyType.Elf:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyElf>(mWeaponType, mPos);
                break;
            case EnemyType.Ogre:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyOgre>(mWeaponType, mPos);
                break;
            case EnemyType.Troll:
                FactoryManager.EnemyFactory.CreateCharacter<EnemyTroll>(mWeaponType, mPos);
                break;
            default:
                break;
        }
       
    }
}
