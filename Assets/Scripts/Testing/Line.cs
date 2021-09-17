using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Line : MonoBehaviour
{
    LineRenderer lineRenderer;
    float counter;
    float dist;

    public Transform origin;
    public Transform destination;

    public float lineSpeed;

    // Start is called before the first frame update
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.enabled = false;
        
    }

    // Update is called once per frame
    void Update()
    {
        lineRenderer.SetPosition(1, destination.position);

        //lineRenderer.SetPosition(0, origin.position);

        //if (Input.GetKeyDown(KeyCode.P))
        //{
        //    lineRenderer.enabled = true;
        //    Debug.Log("draw");
        //    dist = Vector2.Distance(origin.position, destination.position);
        //    Debug.Log(dist);
        //    if (counter < dist)
        //    {
        //        counter += 0.1f / lineSpeed;

        //        float x = Mathf.Lerp(0, dist, counter);

        //        Vector3 pointA = origin.position;
        //        Vector3 pointB = destination.position;

        //        Vector3 lineDirection = x * Vector3.Normalize(pointB - pointA) + pointA;

        //        lineRenderer.SetPosition(1, lineDirection);
        //    }
        //}
    }

    public void DrawToTarget(Vector3 startPos, Transform target)
    {
        lineRenderer.enabled = true;
        lineRenderer.positionCount = 2;
        lineRenderer.SetPosition(0, startPos);
        destination = target;
    }
}
