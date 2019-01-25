using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour
{
    public Sprite interactImg;
    private bool canBeInteractedWith = false;

    [SerializeField]
    private bool canBePickedUp = false;

    private void OnTriggerEnter(Collider other)
    {
        //TODO: oskarin välkkyminen
        //oskari.välky();

        //TODO: tell player to pick up item
        if(other.GetComponent<PlayerController>())
        {
            Debug.Log("Interact with " + gameObject.transform.root.name);
            //PickUpImg();
            canBeInteractedWith = true;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canBeInteractedWith)
            InteractWithItem();
    }

    private void OnTriggerExit(Collider other)
    {
        //TODO: oskari.lopetaVälkkyminen();
        canBeInteractedWith = false;
        
        if (!canBePickedUp)
        {
            GameManager.GM.pickedUpImg.SetActive(false);
        }
    }

    public void InteractWithItem()
    {
        //TODO:
        //gamemanager.hasItem = true;
        //gamemanager.item = this;

        if(canBePickedUp)
        {
            GameManager.GM.ShowPickupImg(interactImg);
            Destroy(gameObject.transform.root.gameObject);
        }
        else
        {
            GameManager.GM.ShowInteractImg(interactImg);
        }
    }
}
