using UnityEngine;
using System.Collections;

public static class MDelegate {
	public delegate void VoidVoidDel();
	public delegate void VoidIntDel(int a);

	public static VoidVoidDel ResetMap;

}
