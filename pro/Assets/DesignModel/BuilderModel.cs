using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace builder
{
    class Person
    {
        List<string> parts = new List<string>();
        public void AddPart(string part)
        {
            parts.Add(part);
        }
        public void show()
        {
            foreach (string p in parts)
            {
                Debug.Log(p);
            }
        }
    }

    class FatPerson : Person { }
    class ThinPerson : Person { }

    interface IBuilder
    {
        void adddHead();
        void addBody();
        void addHand();
        void addFeet();
        Person getResult();
    }
    class FatPersonBuilder : IBuilder
    {
        private Person person;

        public FatPersonBuilder()
        {
            person = new FatPerson();
        }
        public void addBody()
        {
            person.AddPart("胖人身体");
        }

        public void adddHead()
        {
            person.AddPart("胖人头");
        }

        public void addFeet()
        {
            person.AddPart("胖人脚");
        }

        public void addHand()
        {
            person.AddPart("胖人手");
        }

        public Person getResult()
        {
            return person;
        }
    }

    class ThinPersonBuilder : IBuilder
    {
        private Person person;

        public ThinPersonBuilder()
        {
            person = new ThinPerson();
        }
        public void addBody()
        {
            person.AddPart("瘦人身体");
        }

        public void adddHead()
        {
            person.AddPart("瘦人头");
        }

        public void addFeet()
        {
            person.AddPart("瘦人脚");
        }

        public void addHand()
        {
            person.AddPart("瘦人手");
        }

        public Person getResult()
        {
            return person;
        }
    }
    class Director {
        public static Person construct(IBuilder builder)
        {
            builder.addBody();
            builder.addFeet();
            builder.addHand();
            builder.adddHead();
            return builder.getResult();
        }
    }
    public class BuilderModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            IBuilder fatB = new FatPersonBuilder();
            IBuilder thinB = new ThinPersonBuilder();
            Person fatPeron = Director.construct(fatB);
            fatPeron.show();
        }

        // Update is called once per frame
        void Update()
        {

        }
    }

}
