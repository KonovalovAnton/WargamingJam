using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTeam : MonoBehaviour {

    bool isSad;
    public Material sad;
    public Material happy;

    public MeshRenderer body;
    public PhotonView pv;
    public CaptureOthers capture;

    private void Start()
    {
        if(pv.isMine)
        {
            bool sad = false;
            if (PhotonNetwork.playerList.Length > 1)
            {
                sad = true;
            }
            ChangeMoodRPC(sad);
        }
    }

    public bool IsSad()
    {
        return isSad;
    }

    public void ChangeMoodRPC(bool flag)
    {
        pv.RPC("ChangeMood", PhotonTargets.AllBufferedViaServer, flag);
    }

    [PunRPC]
    void ChangeMood(bool isSad)
    {
        this.isSad = isSad;
        body.material = isSad ? sad : happy;
    }

}
