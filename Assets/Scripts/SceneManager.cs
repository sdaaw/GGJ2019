using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{


    public Image fadeImage;

    public Vector3 roomPosition = new Vector3(0, 0, 0);
    public Vector3 roomRotation = new Vector3(0, 0, 0);

    private SceneState selectedSS;

    public GameObject sceneCamera;

    public List<SceneState> roomList = new List<SceneState>();



    public GameObject currentRoom;
    // public GameObject nextRoom; //switch to this on solve


    public void Start() {
        selectedSS = roomList[0];
        currentRoom = Instantiate(selectedSS.gameObject, roomPosition, Quaternion.Euler(roomRotation));
        PlayerController pc = FindObjectOfType<PlayerController>();
        pc.SetCharacter(selectedSS.characterId);
        Vector3 doorPos = currentRoom.GetComponent<SceneState>().transform.GetChild(0).transform.position;
        pc.transform.position = new Vector3(doorPos.x + 0.5f, pc.transform.position.y, doorPos.z - 2);
        pc.transform.LookAt(sceneCamera.transform);
    }

    public void Update() {
        
        if(Input.GetKeyUp(KeyCode.Space)) {
            //SwitchScene();
        }

    }


    public void SwitchScene(int doorId) {

        if(currentRoom.GetComponent<SceneState>().requiredItem != null)
        {
            PlayerController pc = FindObjectOfType<PlayerController>();
            if (pc.hasItem && pc.currentItem.itemId == currentRoom.GetComponent<SceneState>().requiredItem.GetComponentInChildren<Item>().itemId)
                currentRoom.GetComponent<SceneState>().isSolved = true;
        }

        if(currentRoom.GetComponent<SceneState>().isSolved) {

            //currentSceneState = nextRoom.GetComponent<SceneState>();

            //go to next scene based on door we enter
            //disable player
            //fade and load new scene

            StartCoroutine(RoomTransition(doorId));

        } else {
                StartCoroutine(RoomTransition(0)); //or go to same sceneid
            
                Debug.Log("SWITCHED UNSOLVED SCENE");
            }

    }

    public SceneState getStateWithId(int id)
    {
        for (int i = 0; i < roomList.Count; i++)
            if (id == roomList[i].sceneId)
                return roomList[i];
        return null;
    }

    IEnumerator RoomTransition(int doorId) {

        for(float i = 0; i < 1f; i += 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }

        //set new room here?
        Destroy(currentRoom);

        if (doorId == 1)
        {
            selectedSS = getStateWithId(currentRoom.GetComponent<SceneState>().door1TravelId);
        }
        else if (doorId == 2)
        {
            selectedSS = getStateWithId(currentRoom.GetComponent<SceneState>().door2TravelId);
        }

        GameObject[] items = GameObject.FindGameObjectsWithTag("Item");
        for (int i = 0; i < items.Length; i++)
            Destroy(items[i]);

        PlayerController pc = FindObjectOfType<PlayerController>();
        pc.SetCharacter(selectedSS.characterId);
        Vector3 doorPos = currentRoom.GetComponent<SceneState>().transform.GetChild(0).transform.position;

        pc.transform.position = new Vector3(doorPos.x + 0.5f, pc.transform.position.y, doorPos.z - 2);
        pc.transform.LookAt(sceneCamera.transform);

        currentRoom = Instantiate(selectedSS.gameObject, roomPosition, Quaternion.Euler(roomRotation));

        //change playermodel and place it to start position

        for (float i = 1f; i >= 0f; i -= 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }

        //currentRoom = Instantiate(currentSceneState.gameObject, roomPosition, Quaternion.identity);

    }

}
