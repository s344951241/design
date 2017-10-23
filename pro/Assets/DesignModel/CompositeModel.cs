using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Composite
{
    public abstract class Component {
        protected string mName;
        public string Name { get { return mName; } }

        public List<Component> Children
        {
            get
            {
                return mChildren;
            }

            set
            {
                mChildren = value;
            }
        }

        public Component(string name)
        {
            mName = name;
            mChildren = new List<Component>();
        }
        protected List<Component> mChildren;
        public abstract void AddChild(Component con);
        public abstract void RemoveChild(Component con);
        public abstract Component GetChild(int index);
    }

    public class Leaf : Component
    {
        public Leaf(string name) : base(name)
        {
        }

        public override void AddChild(Component con)
        {
            return;
        }

        public override Component GetChild(int index)
        {
            return null;
        }

        public override void RemoveChild(Component con)
        {
            return;
        }
    }
    public class Composite : Component
    {
        public Composite(string name) : base(name)
        {
        }

        public override void AddChild(Component con)
        {
            mChildren.Add(con);
        }

        public override Component GetChild(int index)
        {
            return mChildren[index];
        }

        public override void RemoveChild(Component con)
        {
            mChildren.Remove(con);
        }
    }
    public class CompositeModel : MonoBehaviour
    {



        // Use this for initialization
        void Start()
        {
            Composite root = new Composite("root");

            Leaf leaf1 = new Leaf("GameObject");
            Leaf leaf2 = new Leaf("GameObject (2)");

            Composite gameObject1 = new Composite("GameObject (1)");

            root.AddChild(leaf1);
            root.AddChild(leaf2);
            root.AddChild(gameObject1);

            Leaf child1 = new Leaf("GameObject");
            Leaf child2 = new Leaf("GameObject (1)");
            gameObject1.AddChild(child1);
            gameObject1.AddChild(child2);

            ReadComponent(root);
        }
        //深度优先
        private void ReadComponent(Component con)
        {
            Debug.Log(con.Name);

            List<Component> children = con.Children;
            if (children == null || children.Count == 0)
            {
                return;
            }
            foreach (Component child in children)
            {
                ReadComponent(child);
            }
        }
        // Update is called once per frame
        void Update()
        {

        }
    }
}


