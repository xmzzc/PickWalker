using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Player : MonoBehaviour {
	public AudioClip[] moveClips;
	public AudioClip[] attackClips;
	public AudioClip dieClip;
	float mTimer = 0;
	float TIME = 0.5f;
	Vector2 mTarPos ;
	Rigidbody2D rg ;
	BoxCollider2D box2d;
	Animator anim;
	MDelegate.VoidIntDel mFoodChangeDel;

	// Use this for initialization
	void Start () {
		mTarPos = new Vector2 (1,1);
		rg = GetComponent<Rigidbody2D> ();
		box2d = GetComponent < BoxCollider2D> ();
		anim = GetComponent<Animator> ();
		GameManager.GetInstance ().Player = gameObject;
	}



	// Update is called once per frame
	void Update () {
		if (GameManager.GetInstance ().isLose)
			return;
		//Vector2.Lerp(transform.position,mTarPos,10*Time.deltaTime));
		mTimer += Time.deltaTime;
		if(mTimer<TIME){
			return;
		}
		if(Input.touchCount>0 || Input.GetMouseButtonDown(0)){
			mTarPos = transform.position;
			Vector2 tv2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			ZDebug.Log ("  touchbegan"+tv2.ToString());


			if (tv2 == mTarPos) {
				return;
			}
			if (Mathf.Abs (tv2.x-mTarPos.x) > Mathf.Abs (tv2.y-mTarPos.y)) {
				int a = tv2.x - mTarPos.x > 0 ? 1 : -1;
				mTarPos += new Vector2 (a, 0);
			} else {
				int a = tv2.y - mTarPos.y > 0 ? 1 : -1;
				mTarPos += new Vector2 (0, a);
			}
			box2d.enabled = false;
			RaycastHit2D r = Physics2D.Linecast (transform.position,mTarPos);//Physics2D.Raycast (transform.position,mTarPos);
			box2d.enabled = true;
			if (r.transform != null) {
				ZDebug.Log ("r.collider.tag = " + r.collider.tag);

				switch (r.transform.tag) {
				case "wall":
					mTarPos = transform.position;
					AudioManager.GetInstance ().RandomPlay (attackClips);
					anim.SetTrigger ("attack");
					r.transform.SendMessage ("Damaged");
					break;
				case "outwall":
					mTarPos = transform.position;
					break;
				case "enemy":
					mTarPos = transform.position;
					break;
				case "food":
					r.transform.SendMessage ("ByEat");
					break;
				case "exit":
					r.transform.SendMessage ("Arrive");
					break;
				default:
					break;
				}

			} 
			if (mTarPos != (Vector2)transform.position) {
				AudioManager.GetInstance ().RandomPlay (moveClips);
				transform.position = mTarPos;
			}
			//rg.MovePosition (mTarPos);
			//ObjectEventDispatcher.dispatcher.dispatchEvent(new UEvent(EventTypeName.FOOD_CHANGE,OFood.walkOffset),this);
			GameManager.GetInstance().OnPlayerMove(OFood.walkOffset);
			mTimer = 0;
		}




	}

	private void Attacked(int hurt){
		anim.SetTrigger ("damage");
		ObjectEventDispatcher.dispatcher.dispatchEvent(new UEvent(EventTypeName.FOOD_CHANGE,hurt),this);
	}
}
