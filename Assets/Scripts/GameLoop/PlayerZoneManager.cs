﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneManager : Photon.PunBehaviour {

    private PartyManager partyManager;
    private ObjectMouvement blockHandler;

	// Use this for early initialization
	void Start () {
        partyManager = PartyManager.instance;
        if (!partyManager)
        {
            Debug.Log("Party Manager could not be retrieved from PlayerZoneManager");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        blockHandler = other.GetComponent<ObjectMouvement>();

        if(blockHandler)
        {
            PhaseType phaseType = partyManager.GetCurrentPhase();
            Transform playerZoneFocus = partyManager.playerZone.transform.GetChild(1);
            Transform consideredFocus = gameObject.transform.GetChild(1);

            if((phaseType == PhaseType.Build && !playerZoneFocus.position.Equals(consideredFocus.position))
               || (phaseType == PhaseType.Destruct && playerZoneFocus.position.Equals(consideredFocus.position)))
            {
                blockHandler.DisableDrop();
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        blockHandler = other.GetComponent<ObjectMouvement>();

        if (blockHandler)
        {
            blockHandler.EnableDrop();
            blockHandler = null;
        }
    }
}
