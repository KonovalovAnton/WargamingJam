using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketJump : MonoBehaviour {

    public PlayerController pc;
    public PhotonView pv;
    public PlayerTeam pt;

    float lastT;
    float dive;
    public float cd = 5;
    public float diveMaxTime = 3;

	void Start () {
        lastT = Time.time;
	}
	
	void Update () {
        if(pv.isMine && !pt.IsSad())
        {
            CheckJump();
        }
	}

    bool rocketing;
    void CheckJump()
    {
        if(rocketing)
        {
            dive += Time.deltaTime;
            if(Input.GetKeyUp(KeyCode.Space) || dive > diveMaxTime)
            {
                lastT = Time.time;
                dive = 0;
                rocketing = false;
                pc.EndRocketJump();
                Debug.Log("JUMP END");
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && Time.time - lastT > cd)
        {
            Debug.Log("JUMP ATTEMP");
            rocketing = pc.StartRocketJump();
        }

    }
}
