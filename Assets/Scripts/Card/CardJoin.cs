using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardJoin : MonoBehaviour {

    List<List<GameObject>> handsList;

	// Use this for initialization
	void Start () {
        handsList = new List<List<GameObject>>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void AddToList(List<GameObject> cardInHand)
    {
        handsList.Add(cardInHand);
    }

    public void EmptyList ()
    {

    }
}
