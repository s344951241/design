using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter{

    protected ICharacterAttr mICA;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected IWeapon mWeapon;

    public IWeapon Weapon {
        set { mWeapon = value; }
    }
    public void Attack(Vector3 pos)
    {
        mWeapon.Fire(pos);
    }
}
