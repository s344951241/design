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
    public ICamp(GameObject gameObject, string name, string icon, SoldierType soldierType, Vector3 pos,float trainTime)
    {
        mGameObject = gameObject;
        mName = name;
        mIcon = icon;
        mSoldierType = soldierType;
        mPosition = pos;
        mTrainTime = trainTime;
    }
    public virtual void Update()
    {

    }
}
