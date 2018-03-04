﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouvement : Photon.PunBehaviour {
    
    GameObject cube;
    float z = 0;

    // TEST
    public bool dropEnabled = true;

    void Start () {
		cube = this.gameObject;
	}

    void Update()
    {
        if(!photonView.isMine)
        {
            return;
        }
        Vector3 pos = Input.mousePosition;
        pos.z = z - Camera.main.transform.position.z;
        cube.transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButton(0))
        {
            z = z + (float)0000.1;
            cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, z);
        }

        if (Input.GetMouseButton(1))
        {
            z = z - (float)00000.1;
            cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, z);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        //if (collision <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            if (dropEnabled)
            {
                cube.GetComponent<BoxCollider>().isTrigger = false;
                cube.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Destroy(this);
            }
            else
            {
                Debug.Log("You cannot drop your block here for now");
            }
        }
    }

    public void DisableDrop()
    {
        dropEnabled = false;
    }

    public void EnableDrop()
    {
        dropEnabled = true;
    }

    /*
    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "bloc")
        {
            collision++;
            Debug.Log("col " + collision);
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.tag == "bloc") { 
        collision--;
        Debug.Log("col " + collision);
        }
    }
*/
}
