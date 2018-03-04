using System.Collections.Generic;
using UnityEngine;

public class PlayerZoneManager : Photon.PunBehaviour {

    private PartyManager partyManager;
    private ObjectMouvement blockHandler;

	// Use this for early initialization
	void Start () {
        partyManager = (PartyManager)FindObjectOfType(typeof(PartyManager));
        if (!partyManager)
        {
            Debug.Log("Party Manager could not be retrieved from PlayerZoneManager");
        }
	}

    void OnTriggerEnter(Collider other)
    {
        blockHandler = other.GetComponent<ObjectMouvement>();

        if(other)
        {
            PhaseType phaseType = partyManager.GetCurrentPhase();

            if((phaseType == PhaseType.Build && !partyManager.TargettingPlayerZone())
               || (phaseType == PhaseType.Destruct && partyManager.TargettingPlayerZone()))
            {
                blockHandler.DisableDrop();
                return;
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (blockHandler)
        {
            blockHandler.EnableDrop();
            blockHandler = null;
        }
    }
