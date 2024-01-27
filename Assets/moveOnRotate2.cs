using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnRotate2 : MonoBehaviour
{
    public GameObject twinObject;
    public Vector3 transvector;

    // Start is called before the first frame update
    void Start()
    {
        transvector = twinObject.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Vector3 dist;
        if(transform.rotation.eulerAngles.x<=90)
        {
            dist =new Vector3(0 ,(90- transform.rotation.eulerAngles.x)/90 * 0.04f, 0 );
        }
        else
        {
            dist = new Vector3(0, 0.04f + (360 - transform.rotation.eulerAngles.x) / 90 * 0.05f, 0);
        }
        //Debug.Log(transvector1.z);
        twinObject.transform.position = new Vector3(twinObject.transform.position.x, transvector.y - dist.y,twinObject.transform.position.z);
        //twinObject.transform.position += dist;
    }
}
