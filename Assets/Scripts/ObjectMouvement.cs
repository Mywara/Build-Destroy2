﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouvement : MonoBehaviour {

    // Use this for initialization
    private GameObject cube;
<<<<<<< HEAD
    float z = 0;
    int collision = 0;
=======
    float z;

>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
    void Start () {
		cube = this.gameObject;
	}

    void Update()
    {

        Vector3 pos = Input.mousePosition;
        pos.z = transform.position.z - Camera.main.transform.position.z;
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
        if (collision <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
<<<<<<< HEAD
            cube.GetComponent<BoxCollider>().isTrigger= false;
            cube.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
=======
>>>>>>> parent of d83575d... Merge remote-tracking branch 'origin/Maxime-Branch' into DarkXolotl
            Destroy(this);
        }
    }

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
}
