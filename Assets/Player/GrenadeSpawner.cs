﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrenadeSpawner : MonoBehaviour {

    public GameObject grenade;
    public float cooldown;
    public PlayerTeam playerTeam;
    public PhotonView pv;
    private float lastGrenadeTime;

	// Use this for initialization
	void Start ()
    {
        lastGrenadeTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		if(pv.isMine && Input.GetKeyDown(KeyCode.Space) && playerTeam.IsSad() && Time.time - lastGrenadeTime > cooldown)
        {
            lastGrenadeTime = Time.time;
            PhotonNetwork.Instantiate(grenade.name, new Vector3(transform.position.x, transform.position.y, grenade.transform.position.z), Quaternion.identity, 0);
        }
	}
}
