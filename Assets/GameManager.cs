using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public bool IsLogEnable = false;

	// Use this for initialization
	void Awake(){
		ZDebug.EnableLog = IsLogEnable;
	}
	void Start () {
	
	}
	

}
