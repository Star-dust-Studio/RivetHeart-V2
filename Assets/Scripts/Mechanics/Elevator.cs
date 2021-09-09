using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] floor;
    public Transform spawnFloor;
    private int currentFloor;
    public float moveSpeed = 2f;
    private bool elevatorEngaged = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = spawnFloor.position;
    }

    private void Update()
    {
        if (elevatorEngaged)
        {
            if (currentFloor <= 0)
            {
                transform.position = Vector2.MoveTowards(transform.position, floor[1].transform.position, Time.deltaTime * moveSpeed);
                if (Vector2.Distance(transform.position, floor[1].transform.position) < 0.1f)
                {
                    elevatorEngaged = false;
                    currentFloor++;
                    Debug.Log(currentFloor);
                }
            }
            else
            {
                transform.position = Vector2.MoveTowards(transform.position, floor[0].transform.position, Time.deltaTime * moveSpeed);
                if (Vector2.Distance(transform.position, floor[0].transform.position) < 0.1f)
                {                    
                    elevatorEngaged = false;
                    currentFloor--;
                    Debug.Log(currentFloor);
                }
            }
        }
    }

    public void EngageElevator()
    {
        elevatorEngaged = true;
    }
}
