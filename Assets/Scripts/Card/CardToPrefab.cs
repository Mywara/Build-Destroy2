using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPrefab : Photon.PunBehaviour
{

    public GameObject detroyObject;
    public GameObject prefab;

    // Use this for initialization
    void Start () {
		
	}

    public void DestroyAndCreate()
    {
        Destroy(this.gameObject);
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity,0);
    }
}
