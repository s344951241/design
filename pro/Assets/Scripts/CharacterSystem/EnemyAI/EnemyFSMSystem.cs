using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFSMSystem  {

    private List<IEnemyState> mStates = new List<IEnemyState>();
    private IEnemyState mCurrState;

    public IEnemyState CurrState
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

    public void addState(IEnemyState state)
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
            mCurrState.doBeforeEntering();
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.StateID == state.StateID)
            {
                Debug.LogError("state is exist");
                return;
            }
        }
        mStates.Add(state);
    }

    public void addState(params IEnemyState[] states)
    {
        foreach (IEnemyState s in states)
        {
            addState(s);
        }
    }

    public void deleteState(EnemyStateID id)
    {
        if (id == EnemyStateID.NullState)
        {
            Debug.LogError("id is null");
            return;
        }
        foreach (IEnemyState s in mStates)
        {
            if (s.StateID == id)
            {
                mStates.Remove(s);
                return;
            }
        }
        Debug.LogError("id is not exist");
    }

    public void performTransition(EnemyTransition trans)
    {
        if (trans == EnemyTransition.NullTransition)
        {
            Debug.LogError("trans is null");
            return;
        }
        EnemyStateID nextId = mCurrState.getOutPutState(trans);
        if (nextId == EnemyStateID.NullState)
        {
            Debug.LogError("no state with trans");
            return;
        }
        foreach (IEnemyState s in mStates)
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
