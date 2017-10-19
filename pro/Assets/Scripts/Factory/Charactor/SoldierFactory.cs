using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 pos, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
       
        string name  ="";
        int maxHp = 0;
        float moveSpeed =0;
        string icon="";
        string prefabName ="";
        if (typeof(T) == typeof(SoldierCaptain))
        {
            name = "上尉士兵";
            maxHp = 100;
            moveSpeed = 3;
            icon = "CaptainIcon";
            prefabName = "Soldier1";
        }
        else if (typeof(T) == typeof(SoldierSergeant))
        {
            name = "中士士兵";
            maxHp = 90;
            moveSpeed = 3;
            icon = "SergeantIcon";
            prefabName = "Soldier3";
        }
        else if (typeof(T) == typeof(SoldierRookie))
        {
            name = "新兵";
            maxHp = 80;
            moveSpeed = 2.5f;
            icon = "RookieIcon";
            prefabName = "Soldier2";
        }

        ICharacterAttr attr = new ICharacterAttr(new SoldierAttrStrategy(), name,lv, maxHp, moveSpeed, icon, prefabName);
        character.Attr = attr;
        //创建角色的游戏物体

        //1加载2实例化TODO
        GameObject characterGO = FactoryManager.AssetFactory.LoadSoldier(prefabName);
        characterGO.transform.position = pos;
        character.GameObject = characterGO;
        //添加武器
        //TODO
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        character.Weapon = weapon;

        return character;
    }
}
