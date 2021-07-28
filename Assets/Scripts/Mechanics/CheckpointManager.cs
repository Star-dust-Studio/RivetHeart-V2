using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance { get; private set; }

    private Transform currentCheckpoint;

    private void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Start()
    {
        currentCheckpoint = GetComponent<Transform>();

        PlayerManager.instance.playerPosition = currentCheckpoint;
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        Debug.Log("checkpoint!");
        currentCheckpoint = checkpoint;
    }

    [ContextMenu("Respawn")]
    public void RespawnPlayer()
    {
        Debug.Log("respawn");
        PlayerManager.instance.playerPosition.position = currentCheckpoint.position;
    }
}
