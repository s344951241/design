using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergySystem : IGameSystem
{
    private const int MAX_ENERGY = 100;

    private float mNowEnergy;

    private float mRecoverSpeed = 3;
    public override void Init()
    {
        base.Init();
        mNowEnergy = MAX_ENERGY;
       
    }

    public override void Update()
    {
        base.Update();
        mFacade.UpdateEnergySilder((int)mNowEnergy, MAX_ENERGY);
        if (mNowEnergy >= MAX_ENERGY)
        {
            return;
        }
        mNowEnergy += mRecoverSpeed * Time.deltaTime;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_ENERGY);
        mFacade.UpdateEnergySilder((int)mNowEnergy, MAX_ENERGY);
    }

    public bool takeEnergy(int value)
    {
        if (mNowEnergy >= value)
        {
            mNowEnergy -= value;
            return true;
        }
        return false;
           
    }

    public void RecycleEnergy(int value)
    {
        mNowEnergy += value;
        mNowEnergy = Mathf.Min(mNowEnergy, MAX_ENERGY);
    }
}
