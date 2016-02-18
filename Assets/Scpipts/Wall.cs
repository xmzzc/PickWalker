using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public int OffsetFood = -1;
	public Sprite damaged;
	private int mHp = 2 ;
	private MDelegate.VoidIntDel mFcDel;
	// Use this for initialization
	void Start () {
		mFcDel = GameManager.GetInstance ().FoodChange;

	}
	
	public void Damaged(){
		ZDebug.Log ("aaaaaaaaaaaaaaa");
		mHp--;
		mFcDel (OffsetFood);
		if (mHp <= 0) {
			Destroy (gameObject);
		}
		SpriteRenderer s = GetComponent<SpriteRenderer> ();
		s.sprite = damaged;
	}
}
