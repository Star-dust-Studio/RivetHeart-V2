using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playAnimBullet : MonoBehaviour
{
    public Animator myclips;
    public string Bullet; //parameter name

    // Start is called before the first frame update
    void Start()
    {
        myclips = GetComponent<Animator>();
    }

    void OnMouseUp()
    {
        myclips.SetTrigger(Bullet);
        print("test");
    }
    // Update is called once per frame
    void Update()
    {

    }
}
