using UnityEngine;
using System.Collections;

public class OnJoinedInstantiate : MonoBehaviour
{
    public Transform SpawnPosition;
    public GameObject[] PrefabsToInstantiate;   // set in inspector

    public void OnJoinedRoom()
    {
        if (this.PrefabsToInstantiate != null)
        {
            foreach (GameObject o in this.PrefabsToInstantiate)
            {
                Debug.Log("Instantiating: " + o.name);

              

                PhotonNetwork.Instantiate(o.name, SpawnPosition.position, Quaternion.identity, 0);
            }
        }
    }
}
