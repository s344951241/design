using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierSergeant : ISoldier {

    protected override void playEffect()
    {
        doPlayEffect("SergeantDeadEffect");
    }

    protected override void playSound()
    {
        doPlaySound("SergeantDeath");
    }
}
