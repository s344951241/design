using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ICharacterAttr  {
    protected string mName;
    protected int mMaxHp;
    protected float mMoveSpeed;

    protected int mCurHp;
    protected string mIcon;

    protected int mLv;
    protected float mCriRate;//暴击率(0-1)

    protected IAttrStrategy mStrategy;

}
