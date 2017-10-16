using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SoldierTransition
{
    NullTransition = 0,
    SeeEnemy,
    NoEnemy,
    CanAttack
}

public enum SoldierStateID
{
    NullState = 0,
    Idle,
    Chase,
    Attack
}
public abstract class ISoldierState {

    protected Dictionary<SoldierTransition, SoldierStateID> map = new Dictionary<SoldierTransition, SoldierStateID>();
    protected SoldierStateID mStateID;

    public SoldierStateID StateID
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
    protected SoldierFSMSystem mFSM;

    public ISoldierState(SoldierFSMSystem fsm,ICharacter character)
    {
        mFSM = fsm;
        mCharacter = character;
    }
    public void addTransition(SoldierTransition trans, SoldierStateID id)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("SoldierState Error:trans can't null");
            return;
        }
        if (id == SoldierStateID.NullState)
        {

            Debug.LogError("SoldierState Error:id can't null");
            return;
        }
        if (map.ContainsKey(trans))
        {
            Debug.LogError("SoldierState Error" + trans + "is already add");
            return;
        }
        map.Add(trans, id);
    }

    public void deleteTransition(SoldierTransition trans)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.LogError("trans not exist");
            return;
        }
        map.Remove(trans);
    }

    public SoldierStateID getOutPutState(SoldierTransition trans)
    {
        if (!map.ContainsKey(trans))
        {
            Debug.LogError("can't find this trans");
            return SoldierStateID.NullState;
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
