using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public  class OFood{
	public static int walkOffset = -2;
	public static int food1Offset = 10;
	public static int food2Offset = 20;
	public static int enemy1 = -15;
	public static int enemy2 = -25;
}
public class GameManager : MonoBehaviour {

	public bool IsLogEnable = false;
	public int Level = 1;
	public int Food = 100;
	public bool isLose = false;
	private const int PASS_ADD_FOOD = 100;
	private const int WALK_EAT_FOOD = 2;
	private static GameManager _instance;

	public static GameManager GetInstance(){
	
		return _instance;
	}
	public List<GameObject> EnemyList = new List<GameObject> ();
	public GameObject Player;
	// Use this for initialization
	void Awake(){
		_instance = this;
		ZDebug.EnableLog = IsLogEnable;
	}
	void Start () {
		ObjectEventDispatcher.dispatcher.addEventListener(EventTypeName.FOOD_CHANGE,FoodChange);
	}
	

	public void FoodChange(UEvent food){
		//ZDebug.Log (food.eventParams.ToString());
		Food += (int) food.eventParams;
		if(Food<=0){
			isLose = true;
			Invoke ("ReStart",3f);
		}
		ZDebug.Log ("Food  = "+Food);
		ObjectEventDispatcher.dispatcher.dispatchEvent (new UEvent(EventTypeName.UI_UPDATE,""),this);
	}
	private void ReStart(){
		Level = 1;
		Food = 100;
		isEnemyAct = false;
		EnemyList.Clear ();
		ObjectEventDispatcher.dispatcher.dispatchEvent (new UEvent(EventTypeName.UI_UPDATE,""),this);
		MDelegate.ResetMap ();
		isLose = false;

	}
	public void LevelPass(){
		Level++;
		Food += PASS_ADD_FOOD;
		isEnemyAct = false;
		EnemyList.Clear ();
		MDelegate.ResetMap ();

	}
	bool isEnemyAct = false;
	public void OnPlayerMove(int food){
		if (isEnemyAct) {
			for (int i = 0; i < EnemyList.Count; i++) {
				EnemyList [i].GetComponent<EnemyCtr> ().DoAction (Player.transform);
			}

			isEnemyAct = false;
		} else {
			isEnemyAct = true;
		}
		FoodChange (new UEvent("",food));
	}

}
