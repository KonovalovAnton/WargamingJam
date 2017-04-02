using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SadIconListener : MonoBehaviour {

    public PlayerTeam pt;
    public UnityEngine.UI.Image image;

	void Update ()
    {
		image.enabled = BlindnessController.Instance.blindnessActivated;
	}
}
