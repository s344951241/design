﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, int lv,BaseAttr baseAttr) : base(strategy, lv,baseAttr)
    {
    }
}
