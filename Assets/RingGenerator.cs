using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class RingGenerator : MonoBehaviour
{
    public GameObject ring;
    public GameObject[] rings = new GameObject[20];
    public float[] lights = new float[4];
    public float[] ri = new float[5];
    public Slider radslide;
    public float radius;
    public TMPro.TMP_Dropdown lightType;
    public TMPro.TMP_Dropdown medType;
    public Material[] mats = new Material[4];
    public Button but;
    public TMP_Text resultop;
    public Light lamp;
    public Slider microFosSlider;
    // Start is called before the first frame update
    void Start()
    {
        lights[0] = 5.890f;
        lights[1] = 6.100f;
        lights[2] = 5.320f;
        lights[3] = 6.700f;
        ri[0] = 1;
        ri[1] = 1.33f;
        ri[2] = 1.36f;
        ri[3] = 1.37f;
        ri[4] = 1.44f;
        radius = 0.5f;
        for (int i=0;i<20;i++)
        {
            rings[i] = Instantiate(ring); 
            rings[i].transform.localScale = new Vector3(Mathf.Sqrt((2*i+1)*radius*lights[0]/2), Mathf.Sqrt((2 * i + 1) * radius * lights[0] / 2), Mathf.Sqrt((2 * i + 1) * radius * lights[0] / 2));
        }
    }

    void onclick()
    {
        lightType.value = 0;
        medType.value = 0;
    }
    // Update is called once per frame
    void Update()
    {
        but.onClick.AddListener(onclick);
        radius = 0.5f+radslide.value*0.05f;
        for (int i = 0; i < 20; i++)
        {
            lamp.color = mats[lightType.value].color;
            rings[i].GetComponent<Renderer>().material.color = new Color(mats[lightType.value].color.r, mats[lightType.value].color.g, mats[lightType.value].color.b, (4f - Mathf.Abs(4f - microFosSlider.value))/4);
            rings[i].GetComponent<Renderer>().material.SetColor("_EmissionColor", new Color(mats[lightType.value].color.r, mats[lightType.value].color.g, mats[lightType.value].color.b, (4f - Mathf.Abs(4f - microFosSlider.value)) / 4f * 255) * (((4f - Mathf.Abs(4f - microFosSlider.value)) / 4f * 1)));
            rings[i].transform.localScale = new Vector3(Mathf.Sqrt((2 * i + 1) * radius * lights[lightType.value] / 2/ri[medType.value]), Mathf.Sqrt((2 * i + 1) * radius * lights[lightType.value] / 2 / ri[medType.value]), Mathf.Sqrt((2 * i + 1) * radius * lights[lightType.value] / 2 / ri[medType.value]));
        }
        //Debug.Log(lights[lightType.value]);
        resultop.text = ((float)lights[lightType.value]*100).ToString();
    }
}
