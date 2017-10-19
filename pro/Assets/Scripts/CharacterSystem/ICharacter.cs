using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public abstract class ICharacter{

    protected ICharacterAttr mAttr;
    protected GameObject mGameObject;
    protected NavMeshAgent mNavAgent;
    protected AudioSource mAudio;
    protected Animation mAnim;
    protected IWeapon mWeapon;

    public void Attack(ICharacter target)
    {
        mWeapon.Fire(target.position);
        mGameObject.transform.LookAt(target.position);
        playAnim("attack");
        target.UnderAttack(mWeapon.Atk+ mAttr.CritValue);
    }

    public virtual void UnderAttack(int damage)
    {
        mAttr.takeDamage(damage);
        //攻击的效果，音效，视效(只有敌人有)

        //死亡的效果，音效，视效(只有战士有)
    }

    public void killed()
    {
        //TODO
    }

    public void Update()
    {
        mWeapon.Update();
    }

    public void playAnim(string name)
    {
        mAnim.CrossFade(name);
    }

    public void moveTo(Vector3 pos)
    {
        mNavAgent.SetDestination(pos);
        playAnim("move");
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

    protected void doPlayEffect(string effectName)
    {
        //加载特效
        GameObject effectGO = FactoryManager.AssetFactory.LoadEffect(effectName);
        effectGO.transform.position = position;

        //控制销
        effectGO.AddComponent<DestoryForTime>().time = 1;
    }
    protected void doPlaySound(string name)
    {
        AudioClip clip = FactoryManager.AssetFactory.LoadAudioClip(name);
        mAudio.clip = clip;
        mAudio.Play();
    }

    //public abstract void UpdateFSMAI(List<ICharacter> targets);
    public float AtkRange {
        get {
            return mWeapon.AtkRange;
        }
    }
    public ICharacterAttr Attr {
        set { mAttr = value; }
    }

    public GameObject GameObject {
        set {
            mGameObject = value;
            mNavAgent = mGameObject.GetComponent<NavMeshAgent>();
            mAudio = mGameObject.GetComponent<AudioSource>();
            mAnim = mGameObject.GetComponentInChildren<Animation>();
        }
    }

    public IWeapon Weapon {
        set {
            mWeapon = value;
            mWeapon.Owner = this;
            GameObject weaponPoint = UnityTool.FindChild(mGameObject,"weapon-point");
            UnityTool.Attach(weaponPoint, mWeapon.GameObject);
        }
    }
}
