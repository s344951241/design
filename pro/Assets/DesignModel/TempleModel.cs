using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class IPeople
{
    public void Eat()
    {
        OrderFoods();
        EatSomething();
        PayBill();
    }

    private void OrderFoods()
    {
        Debug.Log("点菜");
    }
    public virtual void EatSomething()
    {

    }

    private void PayBill()
    {
        Debug.Log("买单");
    }
}

public class NorthPeople : IPeople
{
    public override void EatSomething()
    {
        Debug.Log("我在吃面条");
    }
}
public class SouthPeople : IPeople
{
    public override void EatSomething()
    {
        Debug.Log("我在吃米饭");
    }
}
public class TempleModel : MonoBehaviour {

	// Use this for initialization
	void Start () {
        IPeople people = new NorthPeople();
        people.Eat();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
