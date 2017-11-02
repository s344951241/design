using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace visitor
{

    abstract class IShape {
        public abstract void RunVisit(IShapeVisitor visitor);
    }
    abstract class IShapeVisitor
    {
        public abstract void VisitSphere(Sphere sphere);
        public abstract void VisitCylider(Cylinder cylinder);
        public abstract void VisitCube(Cube cube);
    }
    class AmountVisitor : IShapeVisitor
    {
        public int amount = 0;
        public override void VisitCube(Cube cube)
        {
            amount++;
        }

        public override void VisitCylider(Cylinder cylinder)
        {
            amount++;
        }

        public override void VisitSphere(Sphere sphere)
        {
            amount++;
        }
    }
    class ShapeContainer
    {
        private List<IShape> mShapes = new List<IShape>();

        public void AddShape(IShape shape)
        {
            mShapes.Add(shape);
        }
        public void RunVisitor(IShapeVisitor visitor)
        {
            foreach (IShape shape in mShapes)
            {
                shape.RunVisit(visitor);
            }
        }
        public int GetShapeCount()
        {
            return mShapes.Count;
        }



    }
    class Sphere : IShape
    {
        public override void RunVisit(IShapeVisitor visitor)
        {
            visitor.VisitSphere(this);
        }
    }

    class Cylinder : IShape
    {
        public override void RunVisit(IShapeVisitor visitor)
        {
            visitor.VisitCylider(this);
        }
    }

    class Cube : IShape
    {
        public override void RunVisit(IShapeVisitor visitor)
        {
            visitor.VisitCube(this);
        }
    }

    public class VisitorModel : MonoBehaviour
    {

        // Use this for initialization
        void Start()
        {
            Sphere sphere = new Sphere();
            Cylinder cylinder = new Cylinder();
            Cube cube1 = new Cube();
            Cube cube2 = new Cube();

            ShapeContainer container = new ShapeContainer();
            container.AddShape(sphere);
            container.AddShape(cylinder);
            container.AddShape(cube1);
            container.AddShape(cube2);

            AmountVisitor amountVisitor = new AmountVisitor();
            container.RunVisitor(amountVisitor);
            int amount = amountVisitor.amount;
        }

        // Update is called once per frame
        void Update()
        {

        }
    }
}


