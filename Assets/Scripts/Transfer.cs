using UnityEngine;
using System.Collections;

public class Transfer : MonoBehaviour {
	protected int stage = 0;
	protected bool changing = false;
	protected ulong lightTimer = 0;
	protected ulong worldTimer = 0;
	protected float lightControl = 1f;
	private bool[] complete = new bool[8];
	public GameObject rig;
	public GameObject Ele0;
	public GameObject Ele1;
	public GameObject Ele2;
	private ElevatorControl Ele0Control;
	private ElevatorControl Ele1Control;
	private ElevatorControl Ele2Control;
	// Use this for initialization
	void Start () {
		Ele0Control = Ele0.GetComponent<ElevatorControl> ();
		Ele1Control = Ele1.GetComponent<ElevatorControl> ();
		Ele2Control = Ele2.GetComponent<ElevatorControl> ();
		for(int i = 0; i < 8; i++){
			complete[i] = false;
		}
	}
	
	void FixedUpdate(){
		worldTimer = (ulong)Time.time;
		if (!complete[7]) {
			checkTime ();
		}
		movePlayer ();
	}

	protected void checkTime(){
		if (worldTimer >= 94&& !complete[7]) {
			Ele2Control.callDoor ();
			Ele2.transform.GetChild (0).gameObject.SetActive(true);
			complete [7] = true;
		} else if (worldTimer >= 74 && !complete[6]) {
			Ele2Control.callDoor ();
			Ele2.transform.GetChild (0).gameObject.SetActive(false);
			complete [6] = true;
		} else if (worldTimer >= 64 && !complete[5]) {
			stage++;
			changing = true;
			Ele2.transform.GetChild (0).gameObject.SetActive(true);
			Ele1.transform.GetChild (0).gameObject.SetActive(true);
			complete [5] = true;
		} else if (worldTimer >= 62 && !complete[4]) {
			Ele1Control.callDoor ();
			complete [4] = true;
		} else if (worldTimer >= 42 && !complete[3]) {
			Ele1Control.callDoor ();
			Ele1.transform.GetChild (0).gameObject.SetActive(false);
			complete [3] = true;
		} else if (worldTimer >= 32 && !complete[2]) {
			stage++;
			changing = true;
			Ele1.transform.GetChild (0).gameObject.SetActive(true);
			Ele0.transform.GetChild (0).gameObject.SetActive (true);
			complete [2] = true;
		} else if (worldTimer >= 30 && !complete[1]) {
			Ele0Control.callDoor ();
			complete [1] = true;
		} else if (worldTimer >= 10 && !complete[0]) {
			Ele0Control.callDoor ();
			Ele0.transform.GetChild (0).gameObject.SetActive (false);
			complete [0] = true;
		}
	}

	protected void movePlayer(){
		if (changing) {
			lightTimer++;
			if (lightTimer < 10) {
				lightControl -= 0.1f;
			} else if (lightTimer > 20) {
				lightControl += 0.1f;
			} else if (lightTimer == 15 && stage == 1) {
				lightControl = 0f;
				rig.transform.position = new Vector3 (0, 101, 0);
			} else if (lightTimer == 15 && stage == 2) {
				lightControl = 0f;
				rig.transform.position = new Vector3 (0, 201, 0);
			}
			if (lightTimer >= 30) {
				lightControl = 1f;
				lightTimer = 0;
				changing = false;
			}
			for (int i = 0; i < 3; i++) {
				Ele0.GetComponentsInChildren<Light> () [i].intensity = lightControl;
				Ele1.GetComponentsInChildren<Light> () [i].intensity = lightControl;
				Ele2.GetComponentsInChildren<Light> () [i].intensity = lightControl;
			}
		}
	}
}
