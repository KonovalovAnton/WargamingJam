﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CaptureOthers : MonoBehaviour {

    public PhotonView pv;
    public PlayerTeam me;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(pv.isMine && !me.IsSad())
        {
            PlayerTeam p = collision.gameObject.GetComponent<PlayerTeam>();
            if (p != null && p.IsSad())
            {
                p.ChangeMoodRPC(false);
            }
        }
    }
}
