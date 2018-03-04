using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CardToPrefab : Photon.PunBehaviour
{
    private GameObject detroyObject;
    public GameObject prefab;

    private PartyManager partyManager;
    private int costblock;

    // Use this for initialization
    void Start () {
        partyManager = (PartyManager)FindObjectOfType(typeof(PartyManager));
        if(!partyManager)
        {
            Debug.Log("Party Manager could not be retrieved from Card To Prefab component");
        }
	}

    public void DestroyAndCreate()
    {
        
        PhaseType phaseType = partyManager.GetCurrentPhase();

        costblock = Convert.ToInt32(this.GetComponent<CardDisplay>().costText); 
        
        if (phaseType == PhaseType.Build && partyManager.TargettingPlayerZone()
            || phaseType == PhaseType.Destruct && !partyManager.TargettingPlayerZone())
        {
            if (MoneySystem.instance.BuyItem(costblock))
            {
                prefab = this.GetComponent<CardDisplay>().blockPrefab;
                Destroy(this.gameObject);
                PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity, 0);
            }
            else
            {
                Debug.Log("You don't have enough money");
            }
        }
        else
        {
            //TODO: give the player some feedback
            Debug.Log("You are not allowed to instantiate blocks in this area!");
        }
        /*
        // If we play the card from the stock, reduce the count
        if (this.gameObject.tag == "Stock_Cards") CardManager.instance.stockCount--;
        prefab = this.GetComponent<CardDisplay>().blockPrefab;
        Destroy(this.gameObject);
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity,0);
        */
    }
}
