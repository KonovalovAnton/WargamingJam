using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
    public Rigidbody2D physics;
    public PhotonView pv;
    public Camera cam;

    public int cacheX;
    public int cacheY;

    bool blockMovement;
    bool rocket;

	void Start () {
		if(pv.isMine)
        {
            cam.gameObject.SetActive(true);
        }
	}
	
	void Update () {
        if (pv.isMine)
        {
            if (!blockMovement)
            {
                MoveProcedure();
            }

            if(rocket)
            {
                RocketJump();
            }
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
        /*else
        {
            physics.velocity = physics.velocity * 0.7f;
        }*/
        cacheX = x;
        cacheY = y;
    }

    public bool StartRocketJump()
    {
        if (cacheX == 0 && cacheY == 0)
        {
            Debug.Log("JUMP Fail!");
            return false;
        }
        else
        {
            Debug.Log("JUMP SUCCESS!");
            rocket = true;
            blockMovement = true;
            return true;
        }
    }

    public void Slowdown(float multiplier)
    {
        movementSpeed /= multiplier;
        Debug.Log("new speed: " + movementSpeed);
    }


    public void EndRocketJump()
    {
        rocket = false;
        blockMovement = false;
    }

    void RocketJump()
    {                
        physics.AddForce(new Vector2(cacheX, cacheY).normalized * Time.deltaTime * 1000, ForceMode2D.Impulse);
        Debug.Log("VZUH = " + physics.velocity.magnitude);
        if(physics.velocity.magnitude > 100)
        {
            physics.velocity = physics.velocity.normalized * 50;
        }
    }
}
