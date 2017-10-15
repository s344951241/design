using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Context {
    private IState mState;
    public void setState(IState state)
    {
        mState = state;
    }

    public void Handle(int args)
    {
        mState.Handle(args);
    }
}

public interface IState {
    void Handle(int args);
}

public class ConcreteStateA : IState
{
    private Context mContext;

    public ConcreteStateA(Context context)
    {
        mContext = context;
    }

    public void Handle(int args)
    {
        Debug.Log("ConcreteStateA.Handle" + args);
        if (args > 10)
        {
            mContext.setState(new ConcreteStateB(mContext));
        }
    }
}

public class ConcreteStateB : IState
{
    private Context mContext;
    public ConcreteStateB(Context context)
    {
        mContext = context;
    }
    public void Handle(int args)
    {
        Debug.Log("ConcreteStateB.Handle" + args);
        if (args<= 10)
        {
            mContext.setState(new ConcreteStateA(mContext));
        }
    }
}
public class StateModel:MonoBehaviour{

    void Start()
    {
        Context context = new Context();

        context.setState(new ConcreteStateA(context));

        context.Handle(5);
        context.Handle(20);
        context.Handle(30);
        context.Handle(5);
    }
}
