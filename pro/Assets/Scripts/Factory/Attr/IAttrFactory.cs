using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IAttrFactory {

    BaseAttr getBaseAttr(Type t);
    WeaponBaseAttr getWeaponBaseAttr(WeaponType type);
}
