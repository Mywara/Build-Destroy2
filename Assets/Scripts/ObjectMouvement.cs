using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouvement : MonoBehaviour {

    // Use this for initialization
    private GameObject cube;
    float z = 0;
    bool dropEnabled = true;
    int collision = 0;

    void Start () {
		cube = this.gameObject;
	}

    void Update()
    {
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

        if (collision <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            if (dropEnabled)
            {
                cube.AddComponent<BoxCollider>();
                cube.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                Destroy(this);
            }
            else
            {
                //TODO: give some feedback showing the player the access to this area is not allowed
                Debug.Log("You are not allowed to drop your block in this area right now");
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
