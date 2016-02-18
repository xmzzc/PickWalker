using UnityEngine;
using System.Collections;

public class Food : MonoBehaviour {

	public int OffsetFood = 10;
	MDelegate.VoidIntDel a;
	// Use this for initialization
	void Start () {
		a = GameManager.GetInstance ().FoodChange;
	}

	public void ByEat(){
		if (a!=null) {
			a(OffsetFood);
		}
		Destroy (gameObject);
	}

}
