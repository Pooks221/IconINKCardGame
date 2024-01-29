using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setskybox1 : MonoBehaviour
{
    public OVRPassthroughLayer passthrough;
    public Material defaultSkybox;
    public Material skybox1;
    public Material skybox2;
    public Camera skyboxCamera;
    public bool test;


    private void Start()
    {
        passthrough.enabled = enabled;
        //defaultSkybox = RenderSettings.skybox;
        RenderSettings.skybox = defaultSkybox;
        skyboxCamera.enabled = !enabled;
    }

    public void SetSkyboxToNone()
    {
        RenderSettings.skybox = null;
    }

    public void SetSkyboxToDefault()
    {
        RenderSettings.skybox = defaultSkybox;

    }

    public void togglePassthrough()
    {
        passthrough.hidden = !passthrough.hidden;
        if (passthrough.hidden)
        {
            skyboxCamera.enabled = enabled;
            RenderSettings.skybox = defaultSkybox;
            passthrough.enabled = !enabled;
        }
        if (!passthrough.hidden)
        {
            skyboxCamera.enabled = !enabled;
            passthrough.enabled = enabled;
        }
    }

    public void SetSkybox1()
    {
        RenderSettings.skybox = skybox1;
    }

    public void SetSkybox2()
    {
        RenderSettings.skybox = skybox2;
    }

}