using UnityEngine;
using System.Collections;

public class Wall : MonoBehaviour {
	public Sprite damaged;
	// Use this for initialization
	void Start () {
	
	}
	
	public void Damaged(){
		ZDebug.Log ("aaaaaaaaaaaaaa");
		SpriteRenderer s = GetComponent<SpriteRenderer> ();
		s.sprite = damaged;
	}
}
