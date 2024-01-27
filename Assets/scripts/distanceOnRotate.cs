using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class distanceOnRotate : MonoBehaviour
{
    public GameObject child;
    Vector3 pos;
    //public Transform positionVertex;
    void Start()
    {
        pos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(pos);
    }
}
