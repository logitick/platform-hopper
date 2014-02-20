using UnityEngine;
using System.Collections;

public class PlatformFactory : MonoBehaviour {

	Object[] platforms;

	// Use this for initialization
	void Start () {
		platforms = Resources.LoadAll ("Assets/Prefabs/Platforms");
		Debug.Log (platforms.Length);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
