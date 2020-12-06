using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimBulb : MonoBehaviour
{
    public Animator myclips;
    public string Bulb; //parameter name

    // Start is called before the first frame update
    void Start()
    {
        myclips = GetComponent<Animator>();
    }

    void OnMouseUp()
    {
        myclips.SetTrigger(Bulb);
        print("test");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
