using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Transform[] floor;
    private int currentFloor;

    // Start is called before the first frame update
    void Start()
    {
        currentFloor = 0;
        transform.position = floor[currentFloor].position;
    }

    public void ChangeFloor(int selection)
    {
        transform.Translate(floor[currentFloor + selection].position, Space.Self);
    }
}
