///////////////////////
// Script Contributors:
// Emma Cole
//
//
///////////////////////
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //turret trigger here
        //incls visual indicator
    }

    private void OnTriggerExit(Collider other)
    {
        //turn turret off
    }
}
