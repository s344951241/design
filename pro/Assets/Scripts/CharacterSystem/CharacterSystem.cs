using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSystem : IGameSystem
{
    private List<ICharacter> mEnemys = new List<ICharacter>();
    private List<ICharacter> mSoldier = new List<ICharacter>();

    public void addEnemy(IEnemy enemy)
    {
        mEnemys.Add(enemy);
    }

    public void removeEnemy(IEnemy enemy)
    {
        mEnemys.Remove(enemy);
    }

    public void addSoldier(ISoldier soldier)
    {
        mSoldier.Add(soldier);
    }

    public void removeSoldier(ISoldier soldier)
    {
        mSoldier.Remove(soldier);
    }
    public override void Update()
    {
        updateEnemy();
        updateSoldier();
    }

    private void updateEnemy()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.updateFSMAI(mSoldier);
        }
    }

    private void updateSoldier()
    {
        foreach (ISoldier s in mSoldier)
        {
            s.Update();
            s.UpdateFSMAI(mEnemys);
        }
    }
}
