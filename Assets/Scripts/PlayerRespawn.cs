using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    public Vector3 respawnPoint;

    public void RespawnNow()
    {
        transform.position = respawnPoint;
    }

    
}
