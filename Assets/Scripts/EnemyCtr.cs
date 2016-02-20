using UnityEngine;
using System.Collections;


public class EnemyCtr : MonoBehaviour {

	private Rigidbody2D rg2d;
	public AudioClip voicClip;

	// Use this for initialization
	void Start () {
		mTargetPos = transform.position;
		GameManager.GetInstance ().EnemyList.Add (gameObject);
		rg2d = GetComponent<Rigidbody2D> ();
	}
	private Transform player;
	private Vector2 mTargetPos;
	// Update is called once per frame
	void Update () {
		if (!isMove)
			return;
		transform.position = mTargetPos;
		isMove = false;
		//rg2d.MovePosition (Vector2.Lerp (transform.position, mTargetPos, 10 * Time.deltaTime));
//		if (mTargetPos == (Vector2)transform.position) {
//			isMove = false;
//		}

	}
	Vector2 playerPos;
	Vector2 enemyPos;
	public void DoAction(Transform p){
		ZDebug.Log (" enemy DoAction");
		player = p;

		 playerPos = player.position;
		 enemyPos = transform.position;

		if ((Mathf.Abs (enemyPos.x-playerPos.x ) < 1.1 && Mathf.Abs (enemyPos.y-playerPos.y)<0.5) || (Mathf.Abs (enemyPos.x-playerPos.x ) < 0.5 && Mathf.Abs (enemyPos.y-playerPos.y)<1.1) ) {
			Attack ();
		} else {
		
			Move ();
		}

	}
	private void Attack(){
		AudioManager.GetInstance ().RandomPlay (voicClip);
		GetComponent<Animator> ().SetTrigger ("attack");
		player.SendMessage ("Attacked",-10);
	}
	private bool isMove = false;
	private void Move(){

		if (Mathf.Abs (playerPos.x - enemyPos.x) < Mathf.Abs (playerPos.y - enemyPos.y)) {

			int a = enemyPos.y > playerPos.y ? -1 : 1;
			mTargetPos = mTargetPos + new Vector2 (0,a);
		} else {
			int a = enemyPos.x > playerPos.x ? -1 : 1;
			mTargetPos = mTargetPos + new Vector2 (a,0);
		}


		isMove = true;
	}
}
