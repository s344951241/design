using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : ICharacterFactory
{
    public ICharacter CreateCharacter<T>(WeaponType weaponType, Vector3 pos, int lv = 1) where T : ICharacter, new()
    {
        ICharacter character = new T();
        string name = "";
        int maxHp = 0;
        float moveSpeed = 0;
        string icon = "";
        string prefabName = "";

        if (typeof(T) == typeof(EnemyElf))
        {
            name = "精灵";
            maxHp = 100;
            moveSpeed = 3;
            icon = "ElfIcon";
            prefabName = "Enemy1";
        }
        else if (typeof(T) == typeof(EnemyOgre))
        {
            name = "怪物";
            maxHp = 120;
            moveSpeed = 4;
            icon = "OgreIcon";
            prefabName = "Enemy2";
        }
        else if (typeof(T) == typeof(EnemyTroll))
        {
            name = "巨魔";
            maxHp = 200;
            moveSpeed = 1;
            icon = "TrollIcon";
            prefabName = "Enemy3";
        }
        ICharacterAttr attr = new ICharacterAttr(new EnemyAttrStrategy(), name, lv, maxHp, moveSpeed, icon, prefabName);
        character.Attr = attr;
        //创建角色的游戏物体

        //1加载2实例化TODO
        GameObject characterGO = FactoryManager.AssetFactory.LoadEnemy(prefabName);
        characterGO.transform.position = pos;
        character.GameObject = characterGO;
        //添加武器
        //TODO
        IWeapon weapon = FactoryManager.WeaponFactory.CreateWeapon(weaponType);
        character.Weapon = weapon;

        return character;
    }
}
