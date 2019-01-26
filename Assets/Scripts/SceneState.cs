using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneState : MonoBehaviour
{
    //index?
    public int characterId;

    //which character is playing
    public int sceneId;
    public bool isSolved = false;

    //public List<GameObject> objects = new List<GameObject>();
    [SerializeField]
    public List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa> prefabObjects = new List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>();
    public List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa> objects = new List<Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa>();

    public GameObject scenePrefab;

    public int door1TravelId;
    public int door2TravelId;


    private void Start()
    {   




        if(objects.Count > 0) {

            foreach(Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa o in objects) {
                Destroy(o.obj);
                objects.Remove(o);
            }

        }
        
        foreach(Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa o in prefabObjects) {
            GameObject a = Instantiate(o.obj, o.objPosition, Quaternion.identity);
            objects.Add(o);
        }


        //clock state???
        //animations
        //player can play ->
        //setup two different/same outputs
    }


    public void FixedUpdate() {
        



    }

    [System.Serializable]
    public class Aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa : System.Object {

        public Vector3 objPosition;
        public GameObject obj;
        public bool isPuzzleItem; //deprecate this like you deprecate yourself
    }





}
