using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedupBuff : MonoBehaviour {

    
    public float buffPeriod;
    public float buffDuration;
    public PlayerController playerController;
    public PhotonView photonView;
    public PlayerTeam playerTeam;
    public float speedMultiplier;

    private float lastBuffTime;
    private bool isActivated = false;
    private float activatedTime;

    // Use this for initialization
    void Start () {
        lastBuffTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(photonView.isMine && Input.GetKeyDown(KeyCode.E) && Time.time - lastBuffTime > buffPeriod && playerTeam.IsSad())
        {
            Debug.Log("speedup called");
            isActivated = true;
            playerController.Slowdown(1.0f / speedMultiplier);
            lastBuffTime = Time.time;
            activatedTime = lastBuffTime;
        }
        if(photonView.isMine && Time.time - activatedTime > buffDuration && isActivated)
        {
            isActivated = false;
            playerController.Slowdown(speedMultiplier);
        }
	}
}
