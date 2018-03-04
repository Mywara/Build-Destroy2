using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneManager : Photon.PunBehaviour {

    private PartyManager partyManager;

	// Use this for early initialization
	void Start () {
        partyManager = ((PartyManager)FindObjectOfType(typeof(PartyManager)));
        if (!partyManager)
        {
            Debug.Log("Party Manager could not be retrieved from PlayerZoneManager");
        }
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        
    }

    void OnTriggerExit(Collider other)
    {
        
    }
}
