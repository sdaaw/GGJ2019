using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SceneManager : MonoBehaviour
{


    public Vector3 roomPosition = new Vector3(0, 0, 0);

    private SceneState currentSceneState;

    public GameObject sceneCamera;

    public List<GameObject> roomList = new List<GameObject>();

    public GameObject fadeQuadPrefab;
    public GameObject fadeQuad;

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


        if(isFading) {

            
            if(fadeQuad == null) {
                fadeQuad = Instantiate(fadeQuadPrefab, new Vector3(sceneCamera.transform.position.x, sceneCamera.transform.position.y - 1, sceneCamera.transform.position.z + 1), Quaternion.identity);
            }


            Material fadeQuadMaterial = fadeQuad.GetComponent<Renderer>().materials[2];
            fadeQuad.transform.rotation = sceneCamera.transform.rotation;

            Color color = fadeQuadMaterial.color;
            color.a = Mathf.Sin(Time.time / 2) * Mathf.Cos(Time.time / 4) * 2;
            fadeQuadMaterial.color = color;


        }

    }


    public void SwitchScene() {


        if(currentSceneState.isSolved) {


            Debug.Log("SWITCHED SOLVED SCENE");

            //switch room logic here ?? 


            currentSceneState = nextRoom.GetComponent<SceneState>();
            //StartCoroutine("RoomTransition");
            isFading = true;
            

        } else {

            Debug.Log("SWITCHED UNSOLVED SCENE");

        }


    }

    IEnumerator RoomTransition() {
        yield return new WaitForSeconds(0f);
        //Instantiate(nextRoom, roomPosition, Quaternion.identity);

    }

}
