using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace memento
{

    class Originator
    {
        private string mState;
        public void SetState(string state)
        {
            mState = state;
        }

        public void ShowState()
        {
            Debug.Log("Originator state:" + mState);
        }
        public Memento CreateMemento()
        {
            Memento memento = new Memento();
            memento.SetState(mState);
            return memento;
        }
        public void SetMemento(Memento memento)
        {
            SetState(memento.GetState());
        }
    }

    class Memento
    {
        private string mState;
        public void SetState(string state)
        {
            mState = state;
        }
        public string GetState()
        {
            return mState;
        }
    }

    class CareTaker
    {
        Dictionary<string, Memento> mMementoDic = new Dictionary<string, Memento>();
        public void AddMemento(string version, Memento memento)
        {
            mMementoDic.Add(version, memento);
        }

        public Memento GetMemento(string version)
        {
            if (mMementoDic.ContainsKey(version))
            {
                return mMementoDic[version];
            }
            return null;
        }

    }

    public class MementoModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            //Originator originator = new Originator();
            //originator.SetState("State1");
            //originator.ShowState();

            //Memento memento = originator.CreateMemento();
            //originator.SetState("State2");
            //originator.ShowState();

            //originator.SetMemento(memento);
            //originator.ShowState();

            CareTaker careTaker = new CareTaker();
            Originator originator = new Originator();

            originator.SetState("state1");
            originator.ShowState();

            careTaker.AddMemento("1.0", originator.CreateMemento());

            originator.SetState("state2");
            originator.ShowState();

            careTaker.AddMemento("2.0", originator.CreateMemento());

            originator.SetMemento(careTaker.GetMemento("2.0"));

        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}

