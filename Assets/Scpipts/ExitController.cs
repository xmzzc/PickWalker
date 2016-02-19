using UnityEngine;
using System.Collections;

public class ExitController : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}

	public void Arrive(){
		GameManager.GetInstance ().LevelPass ();
	}
}
