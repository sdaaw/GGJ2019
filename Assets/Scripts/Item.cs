using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    public Sprite interactImg;
    private bool canBeInteractedWith = false;

    public bool isGlowing = false;

    private Material myMat;

    [SerializeField]
    private bool canBePickedUp = false;


    public void Start() {
        myMat = gameObject.transform.root.GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other) {
        //TODO: oskarin välkkyminen
        //oskari.välky();
        //TODO: tell player to pick up item
        if (other.GetComponent<PlayerController>()) {
            isGlowing = true;
            Debug.Log("Interact with " + gameObject.transform.root.name);
            //PickUpImg();
            canBeInteractedWith = true;
        }
    }
    public void FixedUpdate() {
        if(isGlowing) {
            myMat.SetFloat("_RimPower", Mathf.Sin(Time.time * 2) + 1);
        } else {
            myMat.SetFloat("_RimPower", 0f);
        }
    }

    private void OnTriggerExit(Collider other) {
        //TODO: oskari.lopetaVälkkyminen();
        isGlowing = false;
        if(other.GetComponent<PlayerController>()) {
            isGlowing = false;
        }

        canBeInteractedWith = false;

        if (!canBePickedUp) {
            GameManager.GM.pickedUpImg.SetActive(false);
        }
    }

    public void InteractWithItem() {
        if (canBePickedUp && !GameManager.GM.hasItem) {
            GameManager.GM.ShowPickupImg(interactImg);
            GameManager.GM.hasItem = true;
            GameManager.GM.currentItem = this;

            Destroy(gameObject.transform.root.gameObject);
        } else {
            GameManager.GM.ShowInteractImg(interactImg);
        }
    }
}
