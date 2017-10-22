using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseAttr{

    private string mName;
    private int mMaxHp;
    private float mMoveSpeed;
    private string mIcon;
    private string mPrefabName;
    private float mCriRate;//暴击率(0-1)


    public BaseAttr(string name, int maxHp, float movespeed, string icon, string prefabName, float cri)
    {
        mName = name;
        mMaxHp = maxHp;
        mMoveSpeed = movespeed;
        mIcon = icon;
        mPrefabName = prefabName;
        mCriRate = cri;
    }



    public string Name
    {
        get
        {
            return mName;
        }
    }

    public int MaxHp
    {
        get
        {
            return mMaxHp;
        }
    }

    public float MoveSpeed
    {
        get
        {
            return mMoveSpeed;
        }
    }

    public string Icon
    {
        get
        {
            return mIcon;
        }
    }

    public string PrefabName
    {
        get
        {
            return mPrefabName;
        }
    }

    public float CriRate
    {
        get
        {
            return mCriRate;
        }
    }

}
