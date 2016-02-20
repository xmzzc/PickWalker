using UnityEngine;
using System.Collections;

public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;

	public static AudioManager GetInstance(){
		return _instance;
	}

	public AudioSource musicSource ;
	public AudioSource soundSource ;
	void Awake(){
		_instance = this;
	}

	public void RandomPlay(params AudioClip[] clips){
		int index = Random.Range (0,clips.Length);
		GameObject go = new GameObject ();
		AudioSource a = go.AddComponent<AudioSource> ();
		a.clip = clips[index];
		a.Play ();
		Destroy (go, 2f);



	}
}
