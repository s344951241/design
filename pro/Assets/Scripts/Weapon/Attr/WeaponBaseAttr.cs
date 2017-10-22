using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBaseAttr {

    protected string mName;
    protected int mAtk;
    protected float mAtkRange;
    protected string mAssetName;

    public WeaponBaseAttr(string name, int atk, float atkRange,string assetName)
    {
        name = mName;
        mAtk = atk;
        mAtkRange = atkRange;
        mAssetName = assetName;
    }

    public string Name {
        get { return mName; }
    }

    public int Atk
    {
        get { return mAtk; }
    }

    public float AtkRange
    {
        get { return mAtkRange; }
    }
    public string AssetName
    {
        get { return mAssetName; }
    }
}
