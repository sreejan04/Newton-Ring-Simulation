using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceMeasurement : MonoBehaviour
{
    public Transform twinObject;
    private Vector3 position;
    private float distance;
    public Slider twinObjectDistSlider;
    public TMP_Text outputDist;
    public Slider twinObjectOP2Slider;
    public TMP_Text outputOP2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        position = twinObject.position;
    }

    // Update is called once per frame
    private float secondOperation(float value)
    {
        //formula for the second operation
        return value * 2;
    }
    void Update()
    {
        float distance = Vector3.Distance(position, twinObject.position);
        twinObjectDistSlider.value = distance;
        twinObjectOP2Slider.value = secondOperation(distance);
        Debug.Log(distance);
        outputDist.text = distance.ToString();
        outputOP2.text = secondOperation(distance).ToString();
        
    }

    public void UpdateDistance()
    {
        twinObjectDistSlider.value = Vector3.Distance(position, twinObject.position);
    }
}
