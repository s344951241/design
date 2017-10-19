using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr  {
    protected string mName;
    protected int mMaxHp;
    protected float mMoveSpeed;
    protected string mIcon;
    protected string mPrefabName;

    protected int mCurHp;
    protected int mLv;
    protected float mCriRate;//暴击率(0-1)

    protected int mDmgDescValue;

    protected IAttrStrategy mStrategy;
    private IAttrStrategy strategy;

    public ICharacterAttr(IAttrStrategy strategy,string name,int lv,int maxHp,float moveSpeed,string icon,string prefab)
    {
        mName = name;
        mLv = lv;
        mMaxHp = maxHp;
        mMoveSpeed = moveSpeed;
        mIcon = icon;
        mPrefabName = prefab;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.getDmgDescValue(mLv);
        mCurHp = mMaxHp + mStrategy.getAddMaxHPValue(mLv);
    }

    public int CritValue
    {
        get { return mStrategy.getCritDmg(mCriRate); }
    }
    public int CurHp
    {
        get { return mCurHp; }
    }
    public void takeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        mCurHp -= damage;
    }
}
