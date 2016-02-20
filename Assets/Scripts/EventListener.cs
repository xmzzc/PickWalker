using UnityEngine;
using System.Collections;
using System.Collections.Generic;
public class EventListener {
	public delegate void VoidVoidDel();
	public delegate void VoidIntDel(int a);
	public delegate void VoidEvent(object a);

	public static VoidVoidDel Pass;

	Dictionary<string,VoidEvent> dic  = new Dictionary<string,VoidEvent>() ;
	
	public void AddListener(string key,VoidEvent callback){
		
	}
	
}
