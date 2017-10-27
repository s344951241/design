using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ICamp{

    protected GameObject mGameObject;
    protected string mName;
    protected string mIcon;
    protected SoldierType mSoldierType;
    protected Vector3 mPosition;//集合点
    protected float mTrainTime;

    protected List<ITrainCommand> mCommands;

    private float mTrainTimer = 0;

    protected IEnergyStrategy mEnergyCostStrategy;
    protected int mEnergyCostCampUpGrade;
    protected int mEnergyCostWeaponUpGrade;
    protected int mEnergyCostTrain;

    public string Icon
    {
        get
        {
            return mIcon;
        }
    }

    public string Name
    {
        get
        {
            return mName;
        }
    }
    public abstract int Lv { get; }
    public abstract WeaponType WeaponType { get; }
    public abstract int EnergyCostCampUpGrade { get; }
    public abstract int EnergyCostWeaponUpGrade { get; }
    public abstract int EnergyCostTrain { get; }
    public ICamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 pos,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIcon = icon;
        mSoldierType = soldierType;
        mPosition = pos;
        mTrainTime = trainTime;
        mTrainTimer = mTrainTime;
        mCommands = new List<ITrainCommand>();
    }
    public virtual void Update()
    {
        UpdateCommand();
    }
    private void UpdateCommand()
    {
        if (mCommands.Count <= 0)
            return;
        mTrainTimer -= Time.deltaTime;
        if (mTrainTimer <= 0)
        {
            mCommands[0].Excute();
            mCommands.RemoveAt(0);
            mTrainTimer = mTrainTime;
        }
    }

    protected abstract void UpdateEnergyCost();
    public abstract void UpGradeCamp();
    public abstract void UpWeaponGrade();

    public abstract void Train();
    public void CancelTrain()
    {
        if (mCommands.Count > 0)
        {
            mCommands.RemoveAt(mCommands.Count - 1);
            if (mCommands.Count == 0)
            {
                mTrainTimer = mTrainTime;
            }
        }
    }

    public int GetTrainCount {
        get { return mCommands.Count; }
    }
    public float GetTrainRemainingTime
    {
       get { return mTrainTimer; }
    }
}
