using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class SpawnCubes : MonoBehaviour
{
    public GameObject prefabCube;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void spawnCube()
    {
        GameObject go = PhotonNetwork.InstantiateRoomObject(prefabCube.name, this.gameObject.transform.position, this.gameObject.transform.rotation);

    }
}
