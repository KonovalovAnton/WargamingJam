using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlowdownDebuff : MonoBehaviour {

    public PhotonView photonViewRef;
    public float slowdownMultiplier;

    private float lifeTime = 0.0f;
    private float maxLifeTime = 15.0f;
    private Dictionary<int, PlayerController> slowedPlayers = new Dictionary<int, PlayerController>();

    private void OnTriggerEnter2D(Collider2D collision)
    {
        PlayerTeam playerTeam = collision.gameObject.GetComponent<PlayerTeam>();
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();
        PhotonView photonView = collision.gameObject.GetComponent<PhotonView>();
        if (playerTeam != null && !playerTeam.IsSad() && photonView.isMine && !slowedPlayers.ContainsKey(collision.gameObject.GetInstanceID()))
        {
            Debug.Log("onTriggerEntah");
            
            playerController.Slowdown(slowdownMultiplier);
            slowedPlayers.Add(collision.gameObject.GetInstanceID(), playerController);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        PlayerTeam playerTeam = collision.gameObject.GetComponent<PlayerTeam>();
        PhotonView photonView = collision.gameObject.GetComponent<PhotonView>();
        if (playerTeam != null && !playerTeam.IsSad() && photonView.isMine && slowedPlayers.ContainsKey(collision.gameObject.GetInstanceID()))
        {
            collision.gameObject.GetComponent<PlayerController>().Slowdown(1.0f / slowdownMultiplier);
            slowedPlayers.Remove(collision.gameObject.GetInstanceID());
        }
    }

    public void Update()
    {
        if(photonViewRef.isMine)
        {
            lifeTime += Time.deltaTime;
            if(lifeTime > maxLifeTime)
            {
                photonViewRef.RPC("ClearDebuf", PhotonTargets.AllViaServer);
                PhotonNetwork.Destroy(photonViewRef);                
            }
        }
    }

    [PunRPC]
    void ClearDebuf()
    {
        foreach (PlayerController playerController in slowedPlayers.Values)
        {
            playerController.Slowdown(1.0f / slowdownMultiplier);
        }
    }


}
