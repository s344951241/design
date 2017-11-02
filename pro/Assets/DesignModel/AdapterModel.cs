using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace adapter
{
    interface StandardInterface
    {
        void Request();
    }

    class StandarImplementA : StandardInterface
    {
        public void Request()
        {
            Debug.Log("使用标准方法请求");
        }
    }

    class Adapter : StandardInterface
    {
        private NewPlugin mPlugin;

        public Adapter(NewPlugin plugin)
        {
            mPlugin = plugin;
        }
        public void Request()
        {
            mPlugin.SpecificRequest();
        }
    }

    class NewPlugin
    {
        public void SpecificRequest()
        {
            Debug.Log("使用特殊方法请求");
        }
    }

    public class AdapterModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Adapter adaper = new Adapter(new NewPlugin());

            StandardInterface si = adaper;
            si.Request();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


