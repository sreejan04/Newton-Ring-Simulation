using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveOnRotate : MonoBehaviour
{
    public GameObject twinObject;
    public GameObject knob2;
    public Vector3 transvector;
    public Vector3 pos2;
    public GameObject lens2;
    public Vector3 pos3;
    
    // Start is called before the first frame update
    void Start()
    {
        transvector = twinObject.transform.position;
        pos2 = knob2.transform.position;
        pos3 = lens2.transform.position;
    }
    // Update is called once per frame
    void Update()
    {
        Quaternion rotation = transform.rotation;
        Vector3 transvector1 = Quaternion.ToEulerAngles(rotation);
        Vector3 dist;
        if(transvector1.z==0)
        {
            dist = new Vector3(0, 0, 0);
        }
        else if (transvector1.z < 0)
        {
            dist = new Vector3(0, 0, (transvector1.z)* 0.847f * 0.0625f / 3.14f / 0.1197528f * 0.3462652f);
        }
        else
        {
            dist = new Vector3(0, 0, -(6.18f-transvector1.z) * 0.847f * 0.0625f / 3.14f / 0.1197528f * 0.3462652f);
        }
        //Debug.Log(transvector1.z);
        if (rotation.eulerAngles.z!=0)
        {
            twinObject.transform.position = transvector + dist;
            knob2.transform.position = pos2 + dist;
            lens2.transform.position = new Vector3(lens2.transform.position.x, transform.position.y, transvector.z + dist.z);
        }
        //twinObject.transform.position += dist;
    }
}
