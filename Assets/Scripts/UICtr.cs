using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class UICtr : MonoBehaviour {
	public Text foodLabel;
	public Text exitLabel;
	public Text loseLabel;

	// Use this for initialization
	void Start () {
		foodLabel.text =  "Food : 100";
		exitLabel.text = "Level : 1";
		ObjectEventDispatcher.dispatcher.addEventListener (EventTypeName.UI_UPDATE,RefreshUI);
		//foodLabel.GetComponent<GUIText>().text = 
	}

	private void RefreshUI(UEvent evt){
		foodLabel.text = "Food : "+GameManager.GetInstance ().Food+"";
		exitLabel.text = "Level : "+GameManager.GetInstance ().Level+"";
		loseLabel.gameObject.SetActive (GameManager.GetInstance().isLose);
	}



}
