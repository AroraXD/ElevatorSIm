using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Transfer : MonoBehaviour {
	protected int stage = 0;
	protected bool changing = false;
	protected int changeStage = 0;
	protected int flashTimer = 0;
	protected int lightTimer = 0;
	protected ulong worldTimer = 0;
	protected float lightControl = 1f;
	private bool[] complete = new bool[10];
	public GameObject rig;
	public GameObject Ele0;
	public GameObject Ele1;
	public GameObject Ele2;
    public GameObject Ele3;

	public GameObject Light;
	private ElevatorControl Ele0Control;
	private ElevatorControl Ele1Control;
	private ElevatorControl Ele2Control;
    private ElevatorControl Ele3Control;

	private Image lights;
	// Use this for initialization
	void Start () {
		Ele0Control = Ele0.GetComponent<ElevatorControl> ();
		Ele1Control = Ele1.GetComponent<ElevatorControl> ();
		Ele2Control = Ele2.GetComponent<ElevatorControl> ();
        Ele3Control = Ele3.GetComponent<ElevatorControl>();

		for(int i = 0; i < 10; i++){
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
		if (worldTimer >= 290 && !complete[9]){
            Ele3Control.callDoor();
			Ele3Control.isMoving = false;
            complete[9] = true;
        } else if (worldTimer >= 260 && !complete[8]) {
            stage++;
            changing = true;
            complete[8] = true;
			Ele3Control.isMoving = true;
        } else if (worldTimer >= 250 && !complete[7]) {
			Ele2Control.callDoor ();
			Ele2Control.toggleParticles ();
			Ele2Control.state = false;

			complete [7] = true;
		} else if (worldTimer >= 180 && !complete[6]) {
			Ele2Control.callDoor ();
			Ele2Control.toggleParticles ();
			Ele2Control.state = true;
			Ele2Control.isMoving = false;

			complete [6] = true;
		} else if (worldTimer >= 170 && !complete[5]) {
			stage++;
			changing = true;
			complete [5] = true;
			Ele2Control.state = true;
		} else if (worldTimer >= 160 && !complete[4]) {
			Ele1Control.isMoving = false;
			Ele1Control.callDoor ();
			Ele1Control.toggleParticles ();

			complete [4] = true;
		} else if (worldTimer >= 100 && !complete[3]) {
			Ele1Control.callDoor ();
			Ele1Control.toggleParticles ();
			Ele1Control.state = true;
			Ele1Control.isMoving = false;
			complete [3] = true;
		} else if (worldTimer >= 90 && !complete[2]) {
			stage++;
			changing = true;
			complete [2] = true;
			flashTimer = Random.Range (5,20);
			Ele1Control.isMoving = true;
		} else if (worldTimer >= 70 && !complete[1]) {
			complete [1] = true;
			Ele0Control.callDoor ();
			Ele0Control.state = false;
			Ele0Control.toggleParticles ();
			complete [1] = true;
		} else if (worldTimer >= 10 && !complete[0]) {
			Ele0Control.callDoor ();
			Ele0Control.state = true;
			Ele0Control.toggleParticles ();
			complete [0] = true;
			Ele0Control.isMoving = false;

		}	
	}

	protected void movePlayer(){
		if (changing) {
			if (changeStage == 0 || changeStage == 2) {
				lightTimer++;
				if (lightTimer <= flashTimer) {
					lights.color = (new Color (0f, 0f, 0f, 1f));
				} else if (lightTimer > 40 && changeStage == 2) {
					lightTimer = 0;
					changing = false;
					changeStage = 0;
				} else if (lightTimer > 40) {
					changeStage = 1;
					lightTimer = 0;
				} else {
					lights.color = (new Color (0f, 0f, 0f, 0f));
				}
			} else if (changeStage == 1) {
				lightTimer++;
				Debug.Log (lightTimer);
				if (lightTimer < 10) {
					lightControl += 0.1f;
				} else if (lightTimer > 10) {
					lightControl -= 0.1f;
				} else if (lightTimer == 10 && stage == 1) {
					lightControl = 1f;
					rig.transform.position = new Vector3 (0, 101, 0);
				} else if (lightTimer == 10 && stage == 2) {
					lightControl = 1f;
					rig.transform.position = new Vector3 (0, 201, 0);
				}
				if (lightTimer >= 20) {
					flashTimer = Random.Range (5, 20);
					lightControl = 0f;
					lightTimer = 0;
					changeStage = 2;
				}
				lights.color = (new Color (0f, 0f, 0f, lightControl));
			}
		}
	}
}
