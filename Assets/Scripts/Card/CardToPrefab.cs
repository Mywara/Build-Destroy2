using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class CardToPrefab : Photon.PunBehaviour
{
    private GameObject detroyObject;
    public GameObject prefab;

    private PartyManager partyManager;
    private int costblock;
    private Text MoneyText;
    private Text Income;

    // Use this for initialization
    void Start () {
        partyManager = (PartyManager)FindObjectOfType(typeof(PartyManager));
        if(!partyManager)
        {
            Debug.Log("Party Manager could not be retrieved from Card To Prefab component");
        }
        MoneyText = partyManager.transform.GetChild(0).transform.GetChild(4).GetComponent<Text>();
        Income = partyManager.transform.GetChild(0).transform.GetChild(15).GetComponent<Text>();

    }

    public void DestroyAndCreate()
    {
        
        PhaseType phaseType = partyManager.GetCurrentPhase();
        costblock = Convert.ToInt32(this.GetComponent<CardDisplay>().costText.text); 
        
        if (phaseType == PhaseType.Build && partyManager.TargettingPlayerZone()
            || phaseType == PhaseType.Destruct && !partyManager.TargettingPlayerZone())
        {
            if (MoneySystem.instance.BuyItem(costblock))
            {
<<<<<<< HEAD
                MoneyText.text = "Money : " + MoneySystem.instance.money + " $";
                Debug.Log("income " + costblock);
                Income.text = Income.text+  "\n - " + costblock ;
               
=======
                MoneyText.text = "" + MoneySystem.instance.money;
>>>>>>> parent of 332e58b... Merge branch 'master' of https://github.com/Mywara/Build-Destroy2
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
<<<<<<< HEAD


    }

    IEnumerator Disapear(int x)
    {
        while (x >= 0)
        {
            Debug.Log("x" + x);
            x = x - 1;
         
            yield return null;
            Debug.Log("x2" + x);

        }
        Income.text = "aaa";

    }
=======
>>>>>>> parent of 332e58b... Merge branch 'master' of https://github.com/Mywara/Build-Destroy2
    }
