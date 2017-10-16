using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoldierFSMSystem {

    private List<ISoldierState> mStates = new List<ISoldierState>();
    private ISoldierState mCurrState;

    public ISoldierState CurrState
    {
        get
        {
            return mCurrState;
        }

        set
        {
            mCurrState = value;
        }
    }

    public void addState(ISoldierState state)
    {
        if (state == null)
        {
            Debug.LogError("state is null");
            return;
        }
        if (mStates.Count == 0)
        {
            mStates.Add(state);
            mCurrState = state;
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.StateID == state.StateID)
            {
                Debug.LogError("state is exist");
                return;
            }
        }
        mStates.Add(state);
    }

    public void addState(params ISoldierState[] states)
    {
        foreach (ISoldierState s in states)
        {
            addState(s);
        }
    }

    public void deleteState(SoldierStateID id)
    {
        if (id == SoldierStateID.NullState)
        {
            Debug.LogError("id is null");
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.StateID == id)
            {
                mStates.Remove(s);
                return;
            } 
        }
        Debug.LogError("id is not exist");
    }

    public void performTransition(SoldierTransition trans)
    {
        if (trans == SoldierTransition.NullTransition)
        {
            Debug.LogError("trans is null");
            return;
        }
        SoldierStateID nextId =  mCurrState.getOutPutState(trans);
        if (nextId == SoldierStateID.NullState)
        {
            Debug.LogError("no state with trans");
            return;
        }
        foreach (ISoldierState s in mStates)
        {
            if (s.StateID == nextId)
            {
                mCurrState.doBeforeLeaving();
                mCurrState = s;
                mCurrState.doBeforeEntering();
                return;
            }
        }
    }
}
