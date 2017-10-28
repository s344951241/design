using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBuilderDirector{

    public static ICharacter Construct(ICharacterBuilder builder)
    {
        builder.addCharacterAttr();
        builder.addGameObject();
        builder.addWeapon();
        builder.addInCharacterSystem();
        return builder.getResult();
    }
}
