using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {
	public AudioClip[] voicClips;
	public int OffsetFood = 10;
	// Use this for initialization
	void Start () {
		
	}

	public void ByEat(){
		ZDebug.Log ("ffffffffff");
		AudioManager.GetInstance ().RandomPlay (voicClips);
		ObjectEventDispatcher.dispatcher.dispatchEvent (new UEvent(EventTypeName.FOOD_CHANGE,OffsetFood),this);
		gameObject.SetActive (false);
		Destroy (gameObject,2f);
	}

}
