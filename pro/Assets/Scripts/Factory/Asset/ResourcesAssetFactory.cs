﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourcesAssetFactory : IAssetFactory
{
    private const string SoldierPath = "Characters/Soldier/";
    private const string EnemyPath = "Characters/Enemy/";
    private const string WeaponPath = "Weapons/";
    private const string EffectPath = "Effects/";
    private const string AudioPath = "Audios/";
    private const string SpritePath = "Sprites/";

    public AudioClip LoadAudioClip(string name)
    {
        return Resources.Load(SpritePath + name, typeof(AudioClip)) as AudioClip;
    }

    public GameObject LoadEffect(string name)
    {
        return InstantiateGameObject(EffectPath + name);
    }

    public GameObject LoadEnemy(string name)
    {
        return InstantiateGameObject(EnemyPath + name);
    }

    public GameObject LoadSoldier(string name)
    {
        return InstantiateGameObject(SoldierPath + name);
    }

    public Sprite LoadSprite(string name)
    {
        return Resources.Load(SpritePath + name, typeof(Sprite)) as Sprite;
    }

    public GameObject LoadWeapon(string name)
    {
        return InstantiateGameObject(WeaponPath + name);
    }

    private GameObject InstantiateGameObject(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("can't load " + path);
            return null;
        }
        return UnityEngine.GameObject.Instantiate(o) as GameObject;
    }
    private UnityEngine.Object LoadAsset(string path)
    {
        UnityEngine.Object o = Resources.Load(path);
        if (o == null)
        {
            Debug.LogError("can't load " + path);
            return null;
        }
        return o;
    }
}
