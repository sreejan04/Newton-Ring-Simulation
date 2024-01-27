using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PanelController : MonoBehaviour
{
    public GameObject variablePanel;
    public GameObject result;
    public GameObject aim;
    public Button aimbut;
    public Transform lens;
    private Vector3 position;
    private float distance;
    public Slider lensSlider;
    public TMP_Text outputDist;
    public GameObject microPos;
    public GameObject microFos;
    public Toggle lightToggle;
    public TMP_Text op2;
    public Slider radSlider;
    public GameObject quad;
    public Button but;
    public GameObject ins2;
    public GameObject knobptr;
    public GameObject welcome;
    public Button welcomebut;
    public GameObject theory1;
    public GameObject theory2;
    public Button theory1but;
    public GameObject procedure;
    public Button procedbut;
    public Button theory2but;
    public Button mainstart;
    public GameObject mainscreen;
    public GameObject lamp;
    public Slider microFosSlider;
    public RenderTexture screen;
    public GameObject maincamera;
    public AudioSource procedureSound;
    public Camera cam;
    public GameObject lens001;
    public Slider lens001Slider;
    public Vector3 position2;
    public TMP_Text oplens;

   // public Slider twinObjectOP2Slider;
  //  public TMP_Text outputOP2;
    
    
    // Start is called before the first frame update
    void Start()
    {
        position2 = lens001.transform.position;
        maincamera.transform.position = new Vector3(-5.84433746f, 1.26999998f, 0.982607245f);
        lamp.SetActive(false);
        procedure.SetActive(false);
        theory1.SetActive(false);
        theory2.SetActive(false);
        variablePanel.SetActive(false);
        result.SetActive(false);
        position = lens.position;
        microPos.SetActive(false);
        microFos.SetActive(false);
        lightToggle.isOn = false;
        quad.SetActive(false);
        ins2.SetActive(false);
        knobptr.SetActive(false);
        aim.SetActive(false);
        welcome.SetActive(false);
    }

    void onclick()
    {
        microPos.SetActive(false);
        microFos.SetActive(false);
        lightToggle.isOn = false;
        quad.SetActive(false);
        ins2.SetActive(false);
        knobptr.SetActive(false);
        radSlider.value = 0;
        result.SetActive(false);
    }
    public void onmainstart()
    {
        mainscreen.SetActive(false);
        welcome.SetActive(true);
    }
    public void onwelcome()
    {
        maincamera.transform.position = new Vector3(-0.779999971f, 1.26999998f, 0.982607245f);
        welcome.SetActive(false);
        aim.SetActive(true);
        Debug.Log("Welcome button clicked");
    }

    public void onaimclick()
    {
        aim.SetActive(false);
        theory1.SetActive(true);
    }

    public void ontheory1()
    {
        theory1.SetActive(false);
        theory2.SetActive(true);
    }

    public void ontheory2()
    {
        theory2.SetActive(false);
        procedure.SetActive(true);
        maincamera.transform.position = new Vector3(2.54299998f, 1.26999998f, 2.08800006f);
    }

    public void onproced()
    {
        variablePanel.SetActive(true);
        procedureSound.enabled = false;
        maincamera.transform.position = new Vector3(3.9000001f, 1.26999998f, 0.180000007f);
    }
    // Update is called once per frame
    public void Update()
    {
        mainstart.onClick.AddListener(onmainstart);
        welcomebut.onClick.AddListener(onwelcome);
        aimbut.onClick.AddListener(onaimclick);
        theory1but.onClick.AddListener(ontheory1);
        theory2but.onClick.AddListener(ontheory2);
        procedbut.onClick.AddListener(onproced);
        but.onClick.AddListener(onclick);
        //if(op2.IsActive())
        op2.text = (0.5f + 0.05f * radSlider.value).ToString();
        if (lightToggle.IsActive())
        {
            if (lightToggle.isOn == true)
            {
                lamp.SetActive(true);
                knobptr.SetActive(true);
                microPos.SetActive(true);
                microFos.SetActive(true);
                quad.SetActive(true);
                ins2.SetActive(true);
                result.SetActive(true);
                float distance = -(lens.transform.position.z - position.z) / 0.300419f * 6;
                float dist2 = -(lens001.transform.position.y - position2.y);
                /*if(microFosSlider.value<0.5)
                {
                    ScalableBufferManager.ResizeBuffers(256 + (1024 - 256) / 0.5f * (0.5f - microFosSlider.value), 256 + (1024 - 256) / 0.5f * (0.5f - microFosSlider.value));
                }
                else
                {
                    ScalableBufferManager.ResizeBuffers(256 + (1024 - 256) / 0.5f * (0.5f - microFosSlider.value)*-1, 256 + (1024 - 256) / 0.5f * (0.5f - microFosSlider.value)*-1);
                }*/
                if(dist2<0.001)
                {
                    lens001Slider.value = 0;
                    oplens.text = 0.ToString();
                }
                else if(dist2>0.079)
                {
                    lens001Slider.value = 8;
                    oplens.text = 8.ToString();
                }
                else
                {
                    lens001Slider.value = ((int)(dist2 * 1000)) / 10f;
                    oplens.text = lens001Slider.value.ToString();
                }
                if (distance < 0.0001)
                {
                    lensSlider.value = 0;
                    outputDist.text = 0.ToString();
                }
                else if (distance > 5.99f)
                {
                    lensSlider.value = 6;
                    outputDist.text = 6.ToString();
                }
                else
                {
                    lensSlider.value = ((int)(distance * 100)) / 100f;
                    outputDist.text = (((int)(distance * 100)) / 100f).ToString();
                }
            }
            else
            {
                lamp.SetActive(false);
                quad.SetActive(false);
                microPos.SetActive(false);
                microFos.SetActive(false);
                ins2.SetActive(false);
                knobptr.SetActive(false);
            }
        }
    }

    /*public void UpdateDistance()
    {
        lensSlider.value = Vector3.Distance(position, lens.position);
    }*/
}
