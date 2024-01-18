using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using Oculus.Interaction;
using Fusion;
using UnityEngine;

public class CubeOwnership : NetworkBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void OnOwnershipRequest(object[] viewAndPlayer)
    {
        PhotonView view = viewAndPlayer[0] as PhotonView;
        Player requestingPlayer = viewAndPlayer[1] as Player;

        Debug.Log("OnOwnershipRequest(): Player " + requestingPlayer + " requests ownership of: " + view + ".");
        //if (this.TransferOwnershipOnRequest)
        //{
        //    view.TransferOwnership(requestingPlayer);
        //}
    }

    public void RequestOwnership()
    {
        if (!Object.HasStateAuthority)
        {
            Object.RequestStateAuthority();
            gameObject.GetComponent<Renderer>().material.color = Color.green;
        }
    }

    public void RemoveOwnership()
    {
        //Object.ReleaseStateAuthority();
        gameObject.GetComponent<Renderer>().material.color = Color.red;
    }
}
