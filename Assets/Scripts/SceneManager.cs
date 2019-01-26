using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SceneManager : MonoBehaviour
{


    public Image fadeImage;

    public Vector3 roomPosition = new Vector3(0, 0, 0);

    private SceneState currentSceneState;

    public GameObject sceneCamera;

    public List<GameObject> roomList = new List<GameObject>();



    public GameObject currentRoom;
    public GameObject nextRoom; //switch to this on solve




    private bool isFading = false;


    public void Start() {
        currentSceneState = currentRoom.GetComponent<SceneState>();
    }

    public void Update() {
        
        if(Input.GetKeyUp(KeyCode.Space)) {
            SwitchScene();
        }

    }


    public void SwitchScene() {


        if(currentSceneState.isSolved) {


            Debug.Log("SWITCHED SOLVED SCENE");

            StartCoroutine("RoomTransition");
            //switch room logic here ?? joo


            currentSceneState = nextRoom.GetComponent<SceneState>();
            

        } else {

            Debug.Log("SWITCHED UNSOLVED SCENE");

        }


    }

    IEnumerator RoomTransition() {

        for(float i = 0; i < 1f; i += 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }


        for (float i = 1f; i >= 0f; i -= 0.01f) {
            fadeImage.color = new Color(0, 0, 0, i);
            yield return new WaitForSeconds(0.01f);
        }


        //Instantiate(nextRoom, roomPosition, Quaternion.identity);

    }

}
