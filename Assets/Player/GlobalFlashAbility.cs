using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalFlashAbility : MonoBehaviour {

    public float buffPeriod;
    public float buffDuration;

    public PhotonView photonView;
    public PlayerTeam playerTeam;

    private float lastBuffTime;
    private bool isActivated = false;
    private float activatedTime;

    // Use this for initialization
    void Start()
    {
        lastBuffTime = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (photonView.isMine && Input.GetKeyDown(KeyCode.Q) && Time.time - lastBuffTime > buffPeriod && playerTeam.IsSad())
        {
            isActivated = BlindnessController.Instance.ActivateBlindness();
            if (isActivated)
            {
                lastBuffTime = Time.time;
                activatedTime = lastBuffTime;
            }
        }

        if (photonView.isMine && Time.time - activatedTime > buffDuration && isActivated)
        {
            isActivated = false;
            BlindnessController.Instance.DeactivateBlindness();
        }
    }
}
