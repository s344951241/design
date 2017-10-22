using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr  {
    #region 固定属性
    protected BaseAttr mBaseAttr;
    #endregion

    #region 变化属性
    protected int mCurHp;
    protected int mLv;
    protected int mDmgDescValue;
    #endregion

    protected IAttrStrategy mStrategy;
    private IAttrStrategy strategy;

    public ICharacterAttr(IAttrStrategy strategy,int lv,BaseAttr baseAttr)
    {
        mBaseAttr = baseAttr;
        mLv = lv;
        mStrategy = strategy;
        mDmgDescValue = mStrategy.getDmgDescValue(mLv);
        mCurHp = mBaseAttr.MaxHp + mStrategy.getAddMaxHPValue(mLv);
    }

    public int CritValue
    {
        get { return mStrategy.getCritDmg(mBaseAttr.CriRate); }
    }
    public int CurHp
    {
        get { return mCurHp; }
    }

    public BaseAttr BaseAttr
    {
        get
        {
            return mBaseAttr;
        }

    }

    public void takeDamage(int damage)
    {
        damage -= mDmgDescValue;
        if (damage < 5) damage = 5;
        mCurHp -= damage;
    }
}
