using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCost : MonoBehaviour {

    public Text costIndicator;
    

	// Use this for initialization
	void Start () {
        costIndicator.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnMouseOver()
    {
        costIndicator.enabled = true;
    }

    public void OnMouseExit()
    {
        costIndicator.enabled = false;
    }
}
