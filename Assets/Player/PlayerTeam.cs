using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeam : MonoBehaviour {

    bool isSad;
    Color sad = Color.red;
    Color happy = Color.green;

    public SpriteRenderer body;
    public PhotonView pv;

    private void Start()
    {
        if(pv.isMine)
        {
            bool sad = true;
            if (PhotonNetwork.playerList.Length > 1)
            {
                sad = false;
            }
            pv.RPC("ChangeMood", PhotonTargets.AllBufferedViaServer, sad);
        }
    }

    [PunRPC]
    public void ChangeMood(bool isSad)
    {
        this.isSad = isSad;
        body.color = isSad ? sad : happy;
    }

}
