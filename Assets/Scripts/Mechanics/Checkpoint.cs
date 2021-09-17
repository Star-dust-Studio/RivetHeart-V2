using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    private Transform position;

    // Start is called before the first frame update
    void Start()
    {
        position = this.gameObject.transform;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            CheckpointManager.instance.SetCheckpoint(position);
        }
    }
}
