using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlindnessActivator : MonoBehaviour {

    bool active;
    bool deactive;
    float animTime;
    public float animMaxTime;
    public UnityEngine.UI.Image image;
    public PhotonView pv;

	// Use this for initialization
	void Start () {
		if(pv.isMine)
        {
            BlindnessController.Instance.blindnessActivator = this;
        }
	}
	
	// Update is called once per frame
	void Update () {
        if(active)
        {
            image.enabled = true;
            animTime += Time.deltaTime;
            image.color = new Color(1, 1, 1, animTime / animMaxTime);
            if(animTime > animMaxTime)
            {
                active = false;
                animTime = 0;
            }
        }

        if(deactive)
        {
            animTime += Time.deltaTime;
            image.color = new Color(1, 1, 1, 1 - animTime / animMaxTime);
            if (animTime > animMaxTime)
            {
                image.enabled = false;
                deactive = false;
                animTime = 0;
            }
        }
		
	}

    public void ActivateBlindness()
    {
        active = true;
    }

    public void DeactivateBlindness()
    {
        deactive = true;
    }
}
