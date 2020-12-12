using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] floor;
    private int currentFloor;
    private float moveSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        currentFloor = 0;
        transform.position = floor[currentFloor].position;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            ChangeFloor(1);
        }
    }

    public void ChangeFloor(int selection)
    {
        Debug.Log("change floor");
        if (transform.position.y < floor[currentFloor + selection].transform.position.y)
        {
            //transform.position = Vector2.MoveTowards(transform.position, floor[currentFloor + selection].transform.position, Time.deltaTime * moveSpeed);
            //transform.Translate(Vector3.up * Time.deltaTime);
            transform.Translate(0, Time.deltaTime, 0, Space.World);
        }
        //transform.Translate(floor[currentFloor + selection].position, Space.World);
        //transform.Translate(0, 30, Time.deltaTime * moveSpeed);
        //transform.position = Vector2.MoveTowards(transform.position, floor[currentFloor + selection].transform.position, Time.deltaTime * moveSpeed);
    }
}
