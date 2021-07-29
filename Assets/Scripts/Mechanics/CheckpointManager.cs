using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager instance { get; private set; }

    [SerializeField]
    private Transform spawnpoint;
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
        if (currentCheckpoint != null)
        {
            Debug.Log("got checkpoint");
            currentCheckpoint = GetComponent<Transform>();
        }
        else
        {
            Debug.Log("is null so set spawn");
            currentCheckpoint = spawnpoint;
        }
        PlayerManager.instance.playerPosition.position = currentCheckpoint.position;
    }

    public void SetCheckpoint(Transform checkpoint)
    {
        Debug.Log("checkpoint!");
        currentCheckpoint.position = checkpoint.position;
    }

    [ContextMenu("Respawn")]
    public void RespawnPlayer()
    {
        Debug.Log("respawn");
        PlayerManager.instance.playerPosition.position = currentCheckpoint.position;
    }
}
