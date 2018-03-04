using System.Collections;
using System.Collections.Generic;
using UnityEngine;

<<<<<<< HEAD
public class CardToPrefab : Photon.PunBehaviour
=======
public class CardToPrefab : MonoBehaviour
>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
{

    public GameObject detroyObject;
    public GameObject prefab;
    public Upgrades drawCards;

    // Use this for initialization
    void Start()
    {
        //prefab = this.gameObject.GetComponent<CardDisplay>().blockPrefab;
    }

    public void DestroyAndCreate()
    {
<<<<<<< HEAD
        prefab = this.GetComponent<CardDisplay>().blockPrefab;
        Destroy(this.gameObject);
        drawCards.usingcards();
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity,0);
=======
        // If we play the card from the stock, reduce the count
        if (this.gameObject.tag == "Stock_Cards") CardManager.instance.stockCount--;
        Destroy(this.gameObject);
        Quaternion q = new Quaternion();
        Instantiate(prefab, Vector3.zero, q);
>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
    }
}
