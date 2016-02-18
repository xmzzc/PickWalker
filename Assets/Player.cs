using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	// Use this for initialization
	void Start () {
		mTarPos = new Vector2 (1,1);
		rg = GetComponent<Rigidbody2D> ();
	}

	float mTimer = 0;
	float TIME = 0.5f;
	Vector2 mTarPos ;
	Rigidbody2D rg ;

	// Update is called once per frame
	void Update () {
		rg.MovePosition (Vector2.Lerp(transform.position,mTarPos,10*Time.deltaTime));
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
			RaycastHit2D r = Physics2D.Raycast (transform.position,mTarPos);

			if (r.transform.tag == "wall") {
				mTarPos = transform.position;
				r.transform.SendMessage ("Damaged");
			}


			mTimer = 0;
		}





	}
}
