using UnityEngine;

<<<<<<< HEAD
public class CardToPrefab : Photon.PunBehaviour
=======
public class CardToPrefab : MonoBehaviour
>>>>>>> DarkXolotl
{

    public GameObject detroyObject;
    public GameObject prefab;

    // Use this for initialization
    void Start()
    {
        prefab = this.gameObject.GetComponent<CardDisplay>().blockPrefab;
    }

    public void DestroyAndCreate()
    {
        // If we play the card from the stock, reduce the count
        if (this.gameObject.tag == "Stock_Cards") CardManager.instance.stockCount--;
        Destroy(this.gameObject);
        PhotonNetwork.Instantiate(prefab.name, Vector3.zero, Quaternion.identity,0);
    }
}
