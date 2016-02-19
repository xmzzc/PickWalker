using UnityEngine;
using System.Collections;
public  class OFood{
	public static int walkOffset = -5;
	public static int food1Offset = 10;
	public static int food2Offset = 20;
	public static int enemy1 = -15;
	public static int enemy2 = -25;
}
public class GameManager : MonoBehaviour {

	public bool IsLogEnable = false;
	public int Level = 1;
	public int Food = 100;
	private const int PASS_ADD_FOOD = 100;
	private const int WALK_EAT_FOOD = 2;
	private static GameManager _instance;

	public static GameManager GetInstance(){
	
		return _instance;
	}

	// Use this for initialization
	void Awake(){
		_instance = this;
		ZDebug.EnableLog = IsLogEnable;
	}
	void Start () {
	
	}
	
	public void FoodChange(int food){
		Food += food;
		ZDebug.Log ("food  = " + Food);
	}

	public void LevelPass(){
		Level++;
		Food += PASS_ADD_FOOD;
		MDelegate.Pass ();

	}

}
