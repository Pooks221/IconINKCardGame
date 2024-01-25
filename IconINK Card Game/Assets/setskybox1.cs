using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setskybox1 : MonoBehaviour
{
    private Material defaultSkybox;

    private void Start()
    {
        defaultSkybox = RenderSettings.skybox;
    }

    public void SetSkyboxToNone()
    {
        RenderSettings.skybox = null;
    }

    public void SetSkyboxToDefault()
    {
        RenderSettings.skybox = defaultSkybox;
    }
}