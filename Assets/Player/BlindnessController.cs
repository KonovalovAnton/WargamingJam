using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindnessController : MonoBehaviour {

    static BlindnessController instance;

    public BlindnessActivator blindnessActivator;
    public PhotonView photonView;

    public static BlindnessController Instance
    {
        get
        {
            if(instance == null)
            {
                instance = new BlindnessController();
            }
            return instance;
        }
    }

    public PlayerTeam playerTeam;

	// Use this for initialization
	void Start () {
        instance = this;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public bool activateBlindness()
    {
        if(!blindnessActivated)
        {
            photonView.RPC("blindnessCallback", PhotonTargets.AllViaServer);
            return true;
        }
        return false;
    }

    [PunRPC]
    public void blindnessCallback()
    {
        blindnessActivated = true;
        if(!playerTeam.IsSad())
        {
            //todo: enable effect
            blindnessActivator.activateBlindness();
        }
        else
        {
            //todo: enable icons
        }
    }

    bool blindnessActivated = false;
}
