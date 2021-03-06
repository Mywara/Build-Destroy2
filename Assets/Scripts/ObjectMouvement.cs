﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMouvement : Photon.PunBehaviour {
    
    GameObject cube;
    float z = 0;
    int collision = 0;
    private Transform[] cubes;

    // TEST
    public bool dropEnabled = false;
    public bool notCollision = true;

    void Start () {
		cube = this.gameObject;
        Vector3 targetPos = ArenaManager.instance.GetPlayerZone(PhotonNetwork.player.ID).transform.position;
        z = Vector3.Distance(targetPos, Camera.main.transform.position) - 10;
        if(z<0)
        {
            z = 5;
        }
	}

    void Update()
    {
        if(!photonView.isMine)
        {
            return;
        }
        //Debug.Log(dropEnabled);
        Vector3 pos = Input.mousePosition;
        //pos.z = z - Camera.main.transform.position.z
        pos.z = z;
        cube.transform.position = Camera.main.ScreenToWorldPoint(pos);

        if (Input.GetMouseButton(0))
        {
            z = z + (float)0000.1;
            //cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, z);
        }

        if (Input.GetMouseButton(1))
        {
            z = z - (float)00000.1;
            //cube.transform.position = new Vector3(cube.transform.position.x, cube.transform.position.y, z);
        }

        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.Alpha1))
        {
            cube.transform.Rotate(Vector3.up * 100 * Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.X) || Input.GetKey(KeyCode.Alpha2))
        {
            cube.transform.Rotate(-Vector3.forward * 100 * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.C) || Input.GetKey(KeyCode.Alpha3))
        {
            cube.transform.Rotate(-Vector3.right * 100 * Time.deltaTime);
        }

        if (Input.GetKeyDown(KeyCode.Space))
        //if (collision <= 0 && Input.GetKeyDown(KeyCode.Space))
        {
            if (dropEnabled && notCollision)
            {
                //cube.GetComponent<BoxCollider>().isTrigger = false;
                

                cubes = cube.transform.GetComponentsInChildren<Transform>();
                Debug.Log("lenght" + cubes.Length);

                for(int i = 1; i < cubes.Length;i++) {
                
                    if(cubes[i].name != "Cylinder")
                    {
                        cubes[i].GetComponent<BoxCollider>().isTrigger = false;
                    }
                    else
                    {
                        cubes[i].GetComponent<MeshCollider>().isTrigger = false;
                    }
                    
                }

                cube.transform.GetComponent<Rigidbody>().velocity = Vector3.zero;
                
                photonView.RPC("RbToNotKinematicAndDestory", PhotonTargets.AllViaServer);
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

    private void OnTriggerStay(Collider other)
    {
        
        GameObject otherGO = other.transform.root.gameObject;
        if (otherGO.tag.Equals("bloc") || other.tag.Equals("bloc"))
        {
            //Debug.Log("trigger enter with " + otherGO.name);
            notCollision = false;
        }   
    }

    public void OnTriggerExit(Collider other)
    {
        GameObject otherGO = other.transform.root.gameObject;
        if (otherGO.tag.Equals("bloc") || other.tag.Equals("bloc"))
        {
            //Debug.Log("trigger exit with " + otherGO.name);
            notCollision = true;
        } 
    }

    [PunRPC]
    private void RbToNotKinematicAndDestory()
    {
        cube.GetComponent<Rigidbody>().isKinematic = false;
        Destroy(this);
    }
}
