using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace strategy
{
    public class Context
    {
        public IStrategy strategy;
        public void Cal()
        {
            strategy.Cal();
        }
    }

    public interface IStrategy
    {
        void Cal();
    }

    public class ConcreteStrategyA : IStrategy
    {
        public void Cal()
        {
            Debug.LogWarning("使用A策略");
        }
    }

    public class ConcreteStrategyB : IStrategy
    {
        public void Cal()
        {
            Debug.LogWarning("使用B策略");
        }
    }

    public class StrategyModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Context context = new Context();
            context.strategy = new ConcreteStrategyA();
            context.Cal();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}

