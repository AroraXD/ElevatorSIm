using UnityEngine;
using System.Collections;

public class LightController : MonoBehaviour {
	float pos = 2.5f;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {

	}

	void FixedUpdate(){
		pos = pos - 0.05f;
		gameObject.transform.position = new Vector3 (0f,pos ,-1.5f);
		if (pos < -0.5f) {
			pos = 2.5f;
		}

	}
}
