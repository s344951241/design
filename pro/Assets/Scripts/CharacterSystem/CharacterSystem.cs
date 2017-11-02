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

        removeCharacterIsKilled(mEnemys);
        removeCharacterIsKilled(mSoldier);
    }

    private void updateEnemy()
    {
        foreach (IEnemy e in mEnemys)
        {
            e.Update();
            e.UpdateFSMAI(mSoldier);
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

    private void removeCharacterIsKilled(List<ICharacter> characters)
    {
        List<ICharacter> canDestroyes = new List<ICharacter>();

        foreach (ICharacter character in characters)
        {
            if (character.CanDestroy)
            {
                canDestroyes.Add(character);
            }
        }

        foreach (ICharacter character in canDestroyes)
        {
            character.Release();
            characters.Remove(character);
        }
    }
    public void RunVisitor(ICharacterVisitor visitor)
    {
        foreach (ICharacter c in mEnemys)
        {
            c.RunVisitor(visitor);
        }

        foreach (ICharacter c in mSoldier)
        {
            c.RunVisitor(visitor);
        }
    }
}
