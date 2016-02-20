using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public int OffsetFood = -1;
	public Sprite damaged;
	private int mHp = 2 ;
	// Use this for initialization
	void Start () {

	}
	
	public void Damaged(){
		ZDebug.Log ("wall damage");
		mHp--;
		ObjectEventDispatcher.dispatcher.dispatchEvent (new UEvent(EventTypeName.FOOD_CHANGE,OffsetFood),this);
		if (mHp <= 0) {
			Destroy (gameObject);
		}
		SpriteRenderer s = GetComponent<SpriteRenderer> ();
		s.sprite = damaged;
	}
}
