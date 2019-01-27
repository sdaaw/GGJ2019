using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Item : MonoBehaviour {
    public int itemId;
    public Sprite interactImg;
    public List<Sprite> moresprites = new List<Sprite>();
    public bool canBeInteractedWith = false;

    public bool isGlowing = false;

    private Material myMat;

    [SerializeField]
    private bool canBePickedUp = false;

    public bool inspectingSolves = false;

    public bool triggersSecret = false;

    public void Start() {
        myMat = gameObject.transform.root.GetComponent<Renderer>().material;
    }

    private void OnTriggerEnter(Collider other) {
        if (other.GetComponent<PlayerController>()) {
            isGlowing = true;
            Debug.Log("Interact with " + gameObject.transform.root.name);
            canBeInteractedWith = true;
            other.GetComponent<PlayerController>().nearObject = this;
        }
    }
    public void FixedUpdate() {
        if(isGlowing) {
            myMat.SetFloat("_RimPower", Mathf.Sin(Time.time * 2) + 1);
        } else {
            myMat.SetFloat("_RimPower", 0f);
        }

        /*if (Input.GetKeyDown(KeyCode.E) && canBeInteractedWith)
            InteractWithItem();*/
    }

    private void OnTriggerExit(Collider other) {
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
        if (canBePickedUp) {
            GameManager.GM.ShowPickupImg(interactImg);
            FindObjectOfType<PlayerController>().PutItemToHand(this);
            //gameObject.transform.parent = 
            //Destroy(gameObject.transform.root.gameObject);
        } else {
            if(inspectingSolves)
                FindObjectOfType<SceneState>().isSolved = true;

            if (triggersSecret)
            {
                GameManager.secretFlag = true;
                interactImg = moresprites[0];
            }
            else
            {
                interactImg = moresprites[1];
            }
               
            GameManager.GM.ShowInteractImg(interactImg);
        }
    }
}
