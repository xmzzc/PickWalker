using UnityEngine;
using System.Collections;

public class MapManager : MonoBehaviour {
	public GameObject[] mOutWallPrefab;
	public GameObject[] mWallPrefab;
	public GameObject[] mFlootPrefab;
	public GameObject[] mFoodPrefab;

	private GameObject Map;
	private int Rows = 10;
	private int cols = 10;
	// Use this for initialization
	void Start () {
		InitMap ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void InitMap(){
		Map = new GameObject("Map");
		for(int x = 0;x<Rows;x++){

			for(int y=0;y<cols;y++){

				if (x == 0 || y == 0 || x == Rows - 1 || y == cols - 1) {
					int index = Random.Range (0, mOutWallPrefab.Length);
					GameObject go = GameObject.Instantiate (mOutWallPrefab [index], new Vector3 (x, y, 0),Quaternion.identity) as GameObject;
					go.transform.parent = Map.transform;
				} else {
					int index = Random.Range (0, mFlootPrefab.Length);
					GameObject go = GameObject.Instantiate (mFlootPrefab [index], new Vector3 (x, y, 0),Quaternion.identity) as GameObject;	
					go.transform.parent = Map.transform;
				}




				
			}
			
		}


	}
}
