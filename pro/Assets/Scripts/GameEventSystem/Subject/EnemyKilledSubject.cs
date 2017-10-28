using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyKilledSubject :IGameEventSubject {

    private int mKilledCount = 0;
    public int KilledCount {
        get { return mKilledCount; }
    }

    public override void Notify()
    {
        mKilledCount++;
        base.Notify();
    }
}
