using UnityEngine;

public class CardToPrefab : MonoBehaviour
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
        Quaternion q = new Quaternion();
        Instantiate(prefab, Vector3.zero, q);
    }
}
