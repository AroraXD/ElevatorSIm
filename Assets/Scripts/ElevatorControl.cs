using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour {

	protected bool state = false;
	public GameObject doors;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		//Debug.Log (doors.GetComponentInChildren<DoorControl> ().getState ());
		if (doors.GetComponentInChildren<DoorControl> ().getState () && !state) {
			GetComponent<AudioSource>().Play();
			GetComponentInChildren<LightController> ().setStop(false);
			state = true;
		} else if (!doors.GetComponentInChildren<DoorControl> ().getState () && state) {
			GetComponent<AudioSource>().Stop();
			GetComponentInChildren<LightController> ().setStop(true);
			state = false;
		}
		/*if (doors.GetComponentInChildren<DoorControl> ().getState () && Input.GetKeyDown (KeyCode.Return)){
			doors.GetComponentsInChildren<DoorControl> ()[0].callOpen();
			doors.GetComponentsInChildren<DoorControl> ()[1].callOpen();
		} else if(!doors.GetComponentInChildren<DoorControl> ().getState () && Input.GetKeyDown (KeyCode.Return)){
			doors.GetComponentsInChildren<DoorControl> ()[0].callClose();
			doors.GetComponentsInChildren<DoorControl> ()[1].callClose();
		}*/
	}

	public void callDoor(){
		if (doors.GetComponentInChildren<DoorControl> ().getState ()){
			doors.GetComponentsInChildren<DoorControl> ()[0].callOpen();
			doors.GetComponentsInChildren<DoorControl> ()[1].callOpen();
			Debug.Log("open");
		} else if(!doors.GetComponentInChildren<DoorControl> ().getState ()){
			doors.GetComponentsInChildren<DoorControl> ()[0].callClose();
			doors.GetComponentsInChildren<DoorControl> ()[1].callClose();
			Debug.Log("Close");
		}
	}
}
