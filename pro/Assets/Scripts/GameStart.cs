using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameStart : MonoBehaviour {
    private SceneStateController sceneController;

    void Awake()
    {
        DontDestroyOnLoad(this.gameObject);
    }
	// Use this for initialization
	void Start () {
        sceneController = new SceneStateController();
        sceneController.SetState(new StartState(sceneController),false);


        ICharacter ch = new SoldierCaptain();
        //ch.Weapon = new WeaponGun();
        //ch.Attack(Vector3.zero);
    }
	
	// Update is called once per frame
	void Update () {
        sceneController.StateUpdate();
	}
}
