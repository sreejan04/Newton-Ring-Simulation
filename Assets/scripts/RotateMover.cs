using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateMover : MonoBehaviour
{
    public GameObject rotate_cube;
    public Vector3 translationVector;

    

    // Update is called once per frame
    void Update()
    {
        Quaternion referenceRotation = rotate_cube.transform.rotation;

        Vector3 localTranslation = Quaternion.Inverse(referenceRotation) * translationVector;

        transform.position += rotate_cube.transform.TransformDirection(localTranslation);
        
        
    }
}
