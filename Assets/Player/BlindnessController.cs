using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindnessController : MonoBehaviour {

    static BlindnessController instance;

    public BlindnessActivator blindnessActivator;

    public PhotonView photonView;

    public bool blindnessActivated = false;

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

    public bool ActivateBlindness()
    {
        if(!blindnessActivated)
        {
            photonView.RPC("BlindnessCallback", PhotonTargets.AllViaServer);
            return true;
        }
        return false;
    }

    public bool DeactivateBlindness()
    {
        if (blindnessActivated)
        {
            photonView.RPC("BlindnessEndCallback", PhotonTargets.AllViaServer);
            return true;
        }
        return false;
    }

    [PunRPC]
    public void BlindnessEndCallback()
    {
        blindnessActivated = false;
        if (!playerTeam.IsSad())
        {
            //todo: disable effect
            blindnessActivator.DeactivateBlindness();
        }
        else
        {
            //todo: disable icons
        }
    }

    [PunRPC]
    public void BlindnessCallback()
    {
        blindnessActivated = true;
        if(!playerTeam.IsSad())
        {
            //todo: enable effect
            blindnessActivator.ActivateBlindness();
        }
        else
        {
            //todo: enable icons
        }
    }

}
