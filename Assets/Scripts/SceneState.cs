﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : MonoBehaviour {
    //index?
    public int characterId;

    public GameObject heldItemOnEntry;

    private GameObject helditemInScene;

    //which character is playing
    public int sceneId;
    public bool isSolved = false;
    public bool isSolved2 = false;

    public int solved2Id;

  //public List<GameObject> objects = new List<GameObject>();
  [SerializeField]
    public List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa> prefabObjects = new List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>();
    public List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa> objects = new List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>();

    public GameObject scenePrefab;


    public GameObject clockPrefab;
    public Vector3 clockPosition;

    public int door1TravelId;
    public int door2TravelId;

    private PlayerController m_player;

    public GameObject moodImg;

    public GameObject requiredItem;

    public bool PlayInjuredAnimation;

    private void Start() {

        if (sceneId == 22)
            Application.Quit();

        //init scene here
        m_player = FindObjectOfType<PlayerController>();
        m_player.hasItem = false;
        m_player.currentItem = null;

        if(PlayInjuredAnimation)
        {
            m_player.animator.SetBool("isInjured", true);
        }

        //instantiate different prefabs for every room, this means that we have to move the clock pointers to a certain location IN THE PREFAB OK
        //Instantiate(clockPrefab, clockPosition, Quaternion.identity);

        if(m_player.moodPosition.transform.childCount > 0)
        {
            Transform f = m_player.moodPosition.transform.GetChild(0);
            f.parent = null;
            Destroy(f.gameObject);
        }

        if (moodImg != null)
        {
            m_player.DisplayMood(moodImg);
        }

        //add item to player
        if(heldItemOnEntry != null)
        {
            helditemInScene = Instantiate(heldItemOnEntry.gameObject, Vector3.zero, Quaternion.identity);
            m_player.PutItemToHand(helditemInScene.GetComponentInChildren<Item>());
        }

        //lets destroy the objects that we had in the last scene so those wont stay
        if (objects.Count > 0) {

            foreach (Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa o in objects) {
                Destroy(o.obj);
                objects.Remove(o);
            }

        }
        //lets spawn some objects to the room to distinguish the rooms and add the puzzle elements
        foreach (Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa o in prefabObjects) {
            GameObject a = Instantiate(o.obj, o.objPosition, o.obj.transform.rotation);
            objects.Add(o);
        }

        //clock state???
        //animations
        //player can play ->
        //setup two different/same outputs
    }


    [System.Serializable]
    public class Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa : System.Object {

        public Vector3 objPosition;
        public GameObject obj;
        //public bool isPuzzleItem; //deprecate this like you deprecate yourself
    }





}
