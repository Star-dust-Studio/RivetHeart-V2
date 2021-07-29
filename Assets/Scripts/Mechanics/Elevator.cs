using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] floor;
    private int currentFloor;
    private float moveSpeed = 0.5f;
    [SerializeField]
    private GameObject elevatorBorder;
    private bool elevatorEngaged = false;

    // Start is called before the first frame update
    void Start()
    {
        currentFloor = 0;
        transform.position = floor[currentFloor].position;
        elevatorBorder.SetActive(false);
    }

    private void Update()
    {
        if (elevatorEngaged)
        {
            ChangeFloor();
        }
    }

    [ContextMenu("Change Floor")]
    public void EngageElevator()
    {
        elevatorEngaged = true;
        elevatorBorder.SetActive(true);
    }

    public void ChangeFloor()
    {
        int selection = 1;
        if (transform.position.y < floor[currentFloor + selection].transform.position.y)
        {
            //transform.position = Vector2.MoveTowards(transform.position, floor[currentFloor + selection].transform.position, Time.deltaTime * moveSpeed);
            //transform.Translate(Vector3.up * Time.deltaTime);
            transform.Translate(0, Time.deltaTime, 0, Space.Self);
        }
        else if (transform.position.y >= floor[currentFloor + selection].transform.position.y)
        {
            elevatorEngaged = false;
            elevatorBorder.SetActive(false);
        }
    }
}
