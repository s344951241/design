using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponGun :IWeapon{
    public override void Fire(Vector3 targetPos)
    {
        Debug.Log("显示特效");
        Debug.Log("播放声音");

        //显示枪口特效
        mParticle.Stop();
        mParticle.Play();
        mLight.enabled = true;

        //显示子弹轨迹
        mLine.enabled = true;
        mLine.startWidth = 0.05f;
        mLine.endWidth = 0.05f;
        mLine.SetPosition(0, mGameObject.transform.position);
        mLine.SetPosition(1, targetPos);
        //播放声音
        string clipName = "GunShot";
        AudioClip clip = null;//TODO
        mAudio.clip = clip;
        mAudio.Play();
    }
}
