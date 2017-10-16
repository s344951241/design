using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IWeapon{

    protected int mAtk;
    protected float mAtkRange;
    protected int mAtkPlusValue;

    protected GameObject mGameObject;
    protected ICharacter mOwner;
      
    protected ParticleSystem mParticle;
    protected LineRenderer mLine;
    protected Light mLight;
    protected AudioSource mAudio;

    protected float mEffectDisplayTime = 0;

    public float AtkRange {
        get { return mAtkRange; }
    }

    public void Update()
    {
        if (mEffectDisplayTime > 0)
        {
            mEffectDisplayTime -= Time.deltaTime;
            if (mEffectDisplayTime <= 0)
            {
                disableEffect();
            }
        }

    }
    public void Fire(Vector3 targetPos)
    {
        Debug.Log("显示特效");
        Debug.Log("播放声音");

        //显示枪口特效
        playMuzzleEffect();

        //显示子弹轨迹
        playBulletEffect(targetPos);

        //设置特效显示时间
        setEffectDisplayTime();
        //播放声音
        playSound();
    }
    protected abstract void setEffectDisplayTime();
    protected virtual void playMuzzleEffect()
    {

        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;
    }

    protected abstract void playBulletEffect(Vector3 targetPos);

    protected void DoBulletEffect(float width, Vector3 targetPos)
    {
        mLine.enabled = true;
        mLine.startWidth = width;
        mLine.endWidth = width;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPos);
    }
    protected virtual void playSound()
    {
        
    }

    protected void doSound(string name)
    {
        string clipName = name;
        AudioClip clip = null;//TODO
        mAudio.clip = clip;
        mAudio.Play();
    }
    private void disableEffect()
    {
        mLight.enabled = false;
        mLine.enabled = false;
    }
}
