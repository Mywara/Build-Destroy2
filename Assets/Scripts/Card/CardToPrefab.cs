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
<<<<<<< HEAD
<<<<<<< HEAD
        // If we play the card from the stock, reduce the count
        if (this.gameObject.tag == "Stock_Cards") CardManager.instance.stockCount--;
=======
        prefab = this.GetComponent<CardDisplay>().blockPrefab;
>>>>>>> master
=======
>>>>>>> parent of 247393d... Merge branch 'DarkXolotl' into Maxime-Branch
        Destroy(this.gameObject);
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity,0);
    }
}
