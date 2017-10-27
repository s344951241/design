using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace chain
{
    public abstract class IHandler
    {
        protected IHandler mNextHandler = null;

        public IHandler SetNetHandler
        {
            set { mNextHandler = value; }
        }
        public IHandler setNetHandle(IHandler handler)
        {
            mNextHandler = handler;
            return mNextHandler;
        }
        public virtual void Handler(char problem) { }
    }

    class HandlerA:IHandler
    {
        public override void Handler(char problem)
        {
            if (problem == 'a')
                Debug.Log("处理完了A问题");
            else
            {
                if (mNextHandler != null)
                {
                    mNextHandler.Handler(problem);
                }
            }
        }
    }

    class HandlerB:IHandler
    {
        public override void Handler(char problem)
        {
            if (problem == 'b')
                Debug.Log("处理完了B问题");
            else
            {
                if (mNextHandler != null)
                {
                    mNextHandler.Handler(problem);
                }
            }
        }
    }

    public class ChainModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            char problem = 'a';
            HandlerA handlerA = new HandlerA();
            HandlerB handlerB = new HandlerB();

            handlerA.SetNetHandler = handlerB;
            handlerA.Handler(problem);
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

