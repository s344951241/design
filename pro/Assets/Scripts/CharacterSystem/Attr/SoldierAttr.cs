using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierAttr : ICharacterAttr
{
    public SoldierAttr(IAttrStrategy strategy,int lv,BaseAttr baseAttr) : base(strategy,lv, baseAttr)
    {
    }
}
