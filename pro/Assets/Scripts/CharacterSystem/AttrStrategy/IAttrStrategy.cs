using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrStrategy {
    /// <summary>
    /// 增加的最大血量
    /// </summary>
    /// <param name="lv">等级</param>
    /// <returns></returns>
    int getAddMaxHPValue(int lv);
    /// <summary>
    /// 抵御的伤害
    /// </summary>
    /// <param name="lv">等级</param>
    /// <returns></returns>
    int getDmgDescValue(int lv);
    /// <summary>
    /// 暴击增加的伤害
    /// </summary>
    /// <param name="critRate"></param>
    /// <returns>暴击率</returns>
    int getCritDmg(int critRate);

}
