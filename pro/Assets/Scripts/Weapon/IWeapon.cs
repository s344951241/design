using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IWeapon{

    protected int mAtk;
    protected float mAtkRange;
    protected int mAtkPlusValue;

    protected GameObject mGameObject;
    protected ICharacter mOwner;
      
    protected ParticleSystem mParticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;
    public virtual void Fire(Vector3 targetPos)
    {
        Debug.LogError("武器无法攻击");
    }
}
