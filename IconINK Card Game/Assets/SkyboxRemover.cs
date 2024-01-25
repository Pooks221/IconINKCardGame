using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkyboxController : MonoBehaviour
{
    public void SetSkyboxToNone()
    {
        RenderSettings.skybox = null;
    }
}