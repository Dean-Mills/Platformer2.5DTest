using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            var player = other.gameObject.GetComponent<Player>();
            if (player == null) Debug.LogError("We collided with player but could not get an instance");
            player.OnCollectablePickup();
            Destroy(this.gameObject);
        }
    }
}
