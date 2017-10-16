using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter{

    protected ICharacterAttr mICA;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected Animation mAnim;
    protected IWeapon mWeapon;

    public IWeapon Weapon {
        set { mWeapon = value; }
    }
    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.position);
    }

    public void playAnim(string name)
    {
        mAnim.CrossFade(name);
    }

    public void moveTo(Vector3 pos)
    {
        mNavAgent.SetDestination(pos);
    }
    public Vector3 position
    {
        get {
            if (mGameObject == null)
            {
                Debug.LogError("gameobject is null");
                return Vector3.zero;
            }
            return mGameObject.transform.position;
        }
    }
    public float AtkRange {
        get {
            return mWeapon.AtkRange;
        }
    }
}
