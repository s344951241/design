using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum EnemyTransition
{
    NullTransition = 0,
    CanAttack,
    LostSoldier
}

public enum EnemyStateID
{
    NullState = 0,
    Chase,
    Attack
}
public abstract class IEnemyState {
    protected Dictionary<EnemyTransition, EnemyStateID> map = new Dictionary<EnemyTransition, EnemyStateID>();
    protected EnemyStateID mStateID;

    public EnemyStateID StateID
    {
        get
        {
            return mStateID;
        }

        set
        {
            mStateID = value;
        }
    }
    protected ICharacter mCharacter;
    protected EnemyFSMSystem mFSM;

    public IEnemyState(EnemyFSMSystem fsm, ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }
    public void addTransition(EnemyTransition trans, EnemyStateID id)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("EnemyState Error:trans can't null");
            return;
        }
        if (id == EnemyStateID.NullState)
        {

            Debug.LogError("EnemyState Error:id can't null");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogError("EnemyState Error" + trans + "is already add");
            return;
        }
        map.Add(trans, id);
    }

    public void deleteTransition(EnemyTransition trans)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.LogError("trans not exist");
            return;
        }
        map.Remove(trans);
    }

    public EnemyStateID getOutPutState(EnemyTransition trans)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.LogError("can't find this trans");
            return EnemyStateID.NullState;
        }
        return map[trans];
    }

    public virtual void doBeforeEntering()
    {

    }

    public virtual void doBeforeLeaving()
    {

    }

    public abstract void reason(List<ICharacter> target);
    public abstract void act(List<ICharacter> target);

}
