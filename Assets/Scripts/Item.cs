using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite pickedUpImg;

    private void OnTriggerEnter(Collider other)
    {
        //TODO: oskarin välkkyminen
        //oskari.välky();

        //TODO: tell player to pick up item
        if(other.GetComponent<PlayerController>())
        {
            Debug.Log("Interact with " + this.gameObject.name);
            PickUpImg();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //TODO: oskari.lopetaVälkkyminen();
    }

    public void PickUpImg()
    {
        //TODO:
        //gamemanager.hasItem = true;
        //gamemanager.item = this;

        GameManager.GM.ShowPickedImg(pickedUpImg);
        
    }
}
