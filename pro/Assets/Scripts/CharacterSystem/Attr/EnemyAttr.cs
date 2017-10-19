using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttr : ICharacterAttr
{
    public EnemyAttr(IAttrStrategy strategy, string name, int lv,int maxHp, float moveSpeed, string icon, string prefab) : base(strategy, name, lv,maxHp, moveSpeed, icon, prefab)
    {
    }
}
