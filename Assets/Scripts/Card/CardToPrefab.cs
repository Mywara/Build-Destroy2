using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardToPrefab : Photon.PunBehaviour
{

    public GameObject detroyObject;
    public GameObject prefab;
    public Upgrades drawCards;

    // Use this for initialization
<<<<<<< HEAD
    void Start()
    {
        //prefab = this.gameObject.GetComponent<CardDisplay>().blockPrefab;
    }
=======
    void Start () {
		
	}
>>>>>>> master

    public void DestroyAndCreate()
    {
        prefab = this.GetComponent<CardDisplay>().blockPrefab;
        Destroy(this.gameObject);
        drawCards.usingcards();
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity,0);
    }
}
