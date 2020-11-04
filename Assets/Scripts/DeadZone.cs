using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var player = other.transform.GetComponent<Player>();
            if(player == null)
            {
                Debug.Log("Player is null");
            }
            player.PlayerFalling();
        }
    }
}
