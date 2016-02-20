using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MapManager : MonoBehaviour {
	public GameObject[] mOutWallPrefab;
	public GameObject[] mWallPrefab;
	public GameObject[] mFlootPrefab;
	public GameObject[] mFoodPrefab;
	public GameObject[] mEnemyPrefab;
	public GameObject mExitPrefab;
	public GameObject mPlayerPrefab;
	private GameObject Map;
	private int Rows = 10;
	private int cols = 10;
	private List<Vector2> mPositions = new List<Vector2>();


	private int Level = 1;

	// Use this for initialization
	void Start () {
		MDelegate.ResetMap += ReInitMap;
		Level = GameManager.GetInstance ().Level;
		InitMap ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void InitMap(){
		Level = GameManager.GetInstance ().Level;
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
				if(x>=2 && x<=Rows-3 && y>=2 && y<= cols-3){
					mPositions.Add(new Vector2(x,y));
				}
				
			}
			
		}
		GeneratorEnemy();
		GeneratorExit();
		GeneratorFood();
		GeneratorPlayer();
		GeneratorWall();

	}
	public void ReInitMap(){
		ZDebug.Log ("ReInitMap");
		mPositions.Clear ();
		Destroy (Map);
		InitMap ();
	
	}
	private int GetRandom(int start,int end){
		return Random.Range (start,end);
	}
	private Vector2 NULL_V2 = new Vector2(-987,0);
	private Vector2 GetRandomPos(){
		if (mPositions != null && mPositions.Count > 0) {
			int index = GetRandom (0, mPositions.Count);
			Vector2 v2 = new Vector2 ();
			v2 = mPositions [index];
			mPositions.RemoveAt (index);
			return v2;
		}
		return NULL_V2;
	}
	private void GeneratorWall(){
		int num = Level / 2 + 3;
		num = num > 15 ? 15 : num;
		InstantiateItem (mWallPrefab,num);
	}
	private void GeneratorFood(){
		int num = Level / 2 + 2;
		num = num > 6 ? 6 : num;
		InstantiateItem (mFoodPrefab,num);
	}
	private void GeneratorEnemy(){
		int num = Level / 2 ;
		num = num > 3 ? 3 : num;
		InstantiateItem (mEnemyPrefab,num+1);
	}
	private void GeneratorExit(){
		
		InstantiateItem (new GameObject[]{mExitPrefab},1,new Vector2[]{new Vector2(8,8)});
	}
	private void GeneratorPlayer(){

		InstantiateItem (new GameObject[]{mPlayerPrefab},1,new Vector2[]{new Vector2(1,1)});
	}
	private void InstantiateItem(GameObject[] prefabs,int num,Vector2[] pos = null){
		Vector2 p;
		for (int i = 0; i < num; i++) {
			if (pos == null || pos.Length<=i) {
				p = GetRandomPos ();
			}else{
				p = pos [i];
			}
			if (p == NULL_V2) {
				ZDebug.Log ("MapManager  InstantiateItem():position is null");
				return;
			}
			int index = GetRandom (0,prefabs.Length);
			GameObject go = GameObject.Instantiate (prefabs[index],p,Quaternion.identity) as GameObject;
			go.transform.parent = Map.transform;
		}



	}

}
