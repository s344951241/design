using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace command {

    public abstract class ICommand {
        public abstract void excute();
    }
    public class ConcreteCommand1 : ICommand
    {
        Reciever1 mReciever1;
        public ConcreteCommand1(Reciever1 reciever1)
        {
            mReciever1 = reciever1;

        }
        public override void excute()
        {
            mReciever1.action("Command1");
        }
    }

    public class Reciever1
    {
        public void action(string cmd)
        {
            Debug.Log("receiver cmd" + cmd);
        }

       
    }
    public class Invoker {
        private List<ICommand> mCommands = new List<ICommand>();

        public void addCommand(ICommand cmd)
        {
            mCommands.Add(cmd);
        }
        public void excuteCommand()
        {
            foreach (ICommand cmd in mCommands)
            {
                cmd.excute();
            }
            mCommands.Clear();
        }
       
    }

   
    public class CommandModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Invoker invoker = new Invoker();

            ConcreteCommand1 cmd1 = new ConcreteCommand1(new Reciever1());
            invoker.addCommand(cmd1);
            invoker.excuteCommand();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

