using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
    public Rigidbody2D physics;
    public PhotonView pv;
    public Camera cam;

	void Start () {
		if(pv.isMine)
        {
            cam.gameObject.SetActive(true);
        }
	}
	
	void Update () {
        if (pv.isMine)
        {
            MoveProcedure();
        }		
	}

    void MoveProcedure()
    {
        bool a = Input.GetKey(KeyCode.A);
        bool d = Input.GetKey(KeyCode.D);
        bool w = Input.GetKey(KeyCode.W);
        bool s = Input.GetKey(KeyCode.S);


        int x = a ? -1 : d ? 1 : 0;
        int y = w ? 1 : s ? -1 : 0;
        
        if(a || s || d || w)
        {
            physics.AddForce(new Vector2(x, y).normalized * Time.deltaTime * movementSpeed,ForceMode2D.Impulse);
        }
        else
        {
            physics.velocity = physics.velocity * 0.7f;
        }

    }
}
