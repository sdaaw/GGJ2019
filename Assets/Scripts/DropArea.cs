using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropArea : MonoBehaviour
{
    public Vector3 dropArea;

    private void Awake()
    {
        //dropArea = new Vector3(-4.62f, 23.56f, 82.90971f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if(pc.hasItem)
            {
                pc.canDepositItem = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<PlayerController>())
        {
            PlayerController pc = other.GetComponent<PlayerController>();
            if (pc.hasItem)
            {
                pc.canDepositItem = false;
            }
        }
    }
}
