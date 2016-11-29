using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transfer : MonoBehaviour {
	protected int stage = 0;
	protected bool changing = false;
	protected int changeStage = 0;
	protected ulong lightTimer = 0;
	protected ulong worldTimer = 0;
	protected float lightControl = 1f;
	private bool[] complete = new bool[8];
	public GameObject rig;
	public GameObject Ele0;
	public GameObject Ele1;
	public GameObject Ele2;
	public GameObject Light;
	private ElevatorControl Ele0Control;
	private ElevatorControl Ele1Control;
	private ElevatorControl Ele2Control;
	private Image lights;
	// Use this for initialization
	void Start () {
		Ele0Control = Ele0.GetComponent<ElevatorControl> ();
		Ele1Control = Ele1.GetComponent<ElevatorControl> ();
		Ele2Control = Ele2.GetComponent<ElevatorControl> ();
		for(int i = 0; i < 8; i++){
			complete[i] = false;
		}
		lights = Light.GetComponent<Image> ();
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
			complete [7] = true;
		} else if (worldTimer >= 74 && !complete[6]) {
			Ele2Control.callDoor ();
			complete [6] = true;
		} else if (worldTimer >= 64 && !complete[5]) {
			stage++;
			changing = true;
			complete [5] = true;
		} else if (worldTimer >= 58 && !complete[4]) {
			Ele1Control.callDoor ();
			complete [4] = true;
		} else if (worldTimer >= 42 && !complete[3]) {
			Ele1Control.callDoor ();
			complete [3] = true;
		} else if (worldTimer >= 32 && !complete[2]) {
			stage++;
			changing = true;
			complete [2] = true;
		} else if (worldTimer >= 28 && !complete[1]) {
			Ele0Control.callDoor ();
		} else if (worldTimer >= 10 && !complete[0]) {
			Ele0Control.callDoor ();
			complete [0] = true;
		}
	}

	protected void movePlayer(){
		if (changing) {
			lightTimer++;
			if (lightTimer < 10) {
				lightControl += 0.1f;
			} else if (lightTimer > 20) {
				lightControl -= 0.1f;
			} else if (lightTimer == 15 && stage == 1) {
				lightControl = 1f;
				rig.transform.position = new Vector3 (0, 101, 0);
			} else if (lightTimer == 15 && stage == 2) {
				lightControl = 1f;
				rig.transform.position = new Vector3 (0, 201, 0);
			}
			if (lightTimer >= 30) {
				lightControl = 0f;
				lightTimer = 0;
				changing = false;
			}
			lights.color = (new Color (0f, 0f, 0f, lightControl));
		}
	}
}
