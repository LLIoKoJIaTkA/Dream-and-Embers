using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    public Transform player;
    public int index;

    private void Awake() 
    {
        player = GameObject.Find("Hero").transform;
        if (DataContainer.checkpointIndex == index)
        {
            player.position = transform.position;
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.name == "Hero")
        {              
            if (index > DataContainer.checkpointIndex)
            {
                DataContainer.checkpointIndex = index;
            }
        }
    }
}
