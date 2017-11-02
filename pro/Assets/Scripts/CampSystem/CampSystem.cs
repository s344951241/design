using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampSystem : IGameSystem
{
    private Dictionary<SoldierType, SoldierCamp> mSoldierCamps = new Dictionary<SoldierType, SoldierCamp>();
    private Dictionary<EnemyType, CaptiveCamp> mCaptiveCamps = new Dictionary<EnemyType, CaptiveCamp>();
    public override void Init()
    {
        base.Init();
        InitCamp(SoldierType.Rookie);
        InitCamp(SoldierType.Sergeant);
        InitCamp(SoldierType.Captain);

        InitCamp(EnemyType.Elf);
    }

    private void InitCamp(SoldierType type)
    {
        GameObject gameObject = null;
        string gameObejctName = "";
        string name = "";
        string icon = "";
        Vector3 pos = Vector3.zero;
        float trainTime = 0;

        switch (type)
        {
            case SoldierType.Rookie:
                gameObejctName = "SoldierCamp_Rookie";
                name = "新手";
                icon = "RookieCamp";
                trainTime = 3;
                break;
            case SoldierType.Sergeant:
                gameObejctName = "SoldierCamp_Sergeant";
                name = "中士";
                icon = "SergeantCamp";
                trainTime = 4;
                break;
            case SoldierType.Captain:
                gameObejctName = "SoldierCamp_Captain";
                name = "上尉";
                icon = "CaptainCamp";
                trainTime = 5;
                break;
            default:
                break;
        }
        gameObject = GameObject.Find(gameObejctName);

        pos = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        SoldierCamp camp = new SoldierCamp(gameObject,name,icon,type,pos,trainTime);

        gameObject.AddComponent<CampClick>().Camp = camp;

        mSoldierCamps.Add(type, camp);
    }

    private void InitCamp(EnemyType type)
    {
        GameObject gameObject = null;
        string gameObejctName = "";
        string name = "";
        string icon = "";
        Vector3 pos = Vector3.zero;
        float trainTime = 0;

        switch (type)
        {
            case EnemyType.Elf:
                gameObejctName = "CaptiveCamp_Elf";
                name = "俘兵营";
                icon = "CaptiveCamp";
                trainTime = 3;
                break;
            //case EnemyType.Ogre:
            //    gameObejctName = "SoldierCamp_Sergeant";
            //    name = "中士";
            //    icon = "SergeantCamp";
            //    trainTime = 4;
            //    break;
            //case EnemyType.Troll:
            //    gameObejctName = "SoldierCamp_Captain";
            //    name = "上尉";
            //    icon = "CaptainCamp";
            //    trainTime = 5;
            //    break;
            default:
                break;
        }
        gameObject = GameObject.Find(gameObejctName);

        pos = UnityTool.FindChild(gameObject, "TrainPoint").transform.position;
        CaptiveCamp camp = new CaptiveCamp(gameObject, name, icon, type, pos, trainTime);

        gameObject.AddComponent<CampClick>().Camp = camp;

        mCaptiveCamps.Add(type, camp);
    }
    public override void Update()
    {
        base.Update();
        foreach (SoldierCamp camp in mSoldierCamps.Values)
        {
            camp.Update();
        }

         foreach (CaptiveCamp camp in mCaptiveCamps.Values)
        {
            camp.Update();
        }
    }
}
