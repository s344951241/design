using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampClick : MonoBehaviour {

    private ICamp mCamp;
    public ICamp Camp { set { mCamp = value; } }
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnMouseUpAsButton()
    {
        GameFacade.Instance.showCampInfo(mCamp);
    }
}
