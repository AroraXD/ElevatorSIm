using UnityEngine;
using System.Collections;

public class ElevatorControl : MonoBehaviour {

	protected bool state = false;
	public GameObject doors;
	private DoorControl doorControl;
	private AudioSource audioSource;
	private LightController lightController;
	// Use this for initialization
	void Start () {
		doorControl = doors.GetComponentInChildren<DoorControl> ();
		audioSource = GetComponent<AudioSource> ();
		lightController = GetComponentInChildren<LightController> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){
		//Debug.Log (doors.GetComponentInChildren<DoorControl> ().getState ());
		if (doorControl.getState () && !state) {
			audioSource.Play();
			lightController.setStop(false);
			state = true;
		} else if (!doorControl.getState () && state) {
			audioSource.Stop();
			lightController.setStop(true);
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
		if (doorControl.getState ()){
			doors.GetComponentsInChildren<DoorControl> ()[0].callOpen();
			doors.GetComponentsInChildren<DoorControl> ()[1].callOpen();
			Debug.Log("open");
		} else if(!doorControl.getState ()){
			doors.GetComponentsInChildren<DoorControl> ()[0].callClose();
			doors.GetComponentsInChildren<DoorControl> ()[1].callClose();
			Debug.Log("Close");
		}
	}
}
