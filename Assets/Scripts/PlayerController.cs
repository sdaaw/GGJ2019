using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool AllowMovement;
    public float speed;

    private Rigidbody m_rigidbody;
    private Vector3 m_moveVector;
    private Vector3 m_xMoveVector;
    private Transform m_transform;

    [SerializeField]
    private Camera m_playerCamera;

    [SerializeField]
    private LayerMask m_layerMask;

    [SerializeField]
    private List<GameObject> players = new List<GameObject>();

    [SerializeField]
    private List<GameObject> m_rightHands = new List<GameObject>();

    private GameObject cRightHand;

    public float turnSpeed;

    private Animator animator;

    public GameObject moodPosition;

    public bool hasItem;
    public Item currentItem;
    public bool canDepositItem;

    //private bool pickingUpItem;

    public void SetCharacter(int id)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (i == id)
            {
                if (cRightHand != null && cRightHand.transform.childCount > 0)
                {
                    Transform f = cRightHand.transform.GetChild(0);
                    f.parent = null;
                    Destroy(f.gameObject);
                }
                    
                players[i].SetActive(true);
                animator = players[i].GetComponent<Animator>();
                cRightHand = m_rightHands[i];
                
            }  
            else
                players[i].SetActive(false);
        }
    }

    void Awake()
    {
        m_transform = transform;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (AllowMovement)
            DoMovement();
        if(animator != null) {
            animator.SetFloat("speed", m_rigidbody.velocity.magnitude);
            //Debug.Log(m_rigidbody.velocity.magnitude);
        } else {
            animator = players[3].GetComponent<Animator>();
        }
        if (moodPosition != null)
            moodPosition.transform.LookAt(m_playerCamera.transform);
    }

    private void Update()
    {
        //TODO: Fix to work with E
        if (Input.GetKeyDown(KeyCode.F) && hasItem)
            DropItem();

    }

    private void DropItem()
    {
        if (cRightHand != null && cRightHand.transform.childCount > 0)
        {
            hasItem = false;
            currentItem = null;

            Transform f = cRightHand.transform.GetChild(0);
            f.parent = null;
            f.transform.gameObject.AddComponent<Rigidbody>();

            

            //if in drop area -> put right position -> give flag
            if(canDepositItem)
            {
                FindObjectOfType<SceneState>().isSolved = true;
                //TODO: Do this better and set rotation
                f.transform.position = FindObjectOfType<DropArea>().dropArea;
                Destroy(f.GetComponent<Rigidbody>());
            }
           
        }
    }

    /// <summary>
    /// Do player movement
    /// </summary>
    void DoMovement()
    {
        m_rigidbody.velocity = Vector3.zero;
        m_moveVector = m_xMoveVector;

        m_xMoveVector = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
     
        m_xMoveVector = GetVectorRelativeToObject(m_xMoveVector, m_playerCamera.transform);

        if (m_xMoveVector.magnitude > 0)
        {
            Quaternion targetRotation = Quaternion.LookRotation(m_xMoveVector, Vector3.up);
            m_transform.rotation = Quaternion.Slerp(m_transform.rotation, targetRotation, 0.2f);
        }

        m_rigidbody.velocity = m_moveVector * speed;
    }

    public void DisplayMood(GameObject img)
    {
        GameObject go = Instantiate(img, Vector3.zero, Quaternion.identity);
        go.transform.parent = moodPosition.transform;
        go.transform.position = moodPosition.transform.position;
        //StartCoroutine(ShowMood());
    }

    private IEnumerator ShowMood()
    {
        moodPosition.SetActive(true);
        yield return new WaitForSeconds(2);
        moodPosition.SetActive(false);
    }

    public void PutItemToHand(Item item)
    {
        if(!hasItem)
        {
            if(item.gameObject.transform.root.GetComponent<Rigidbody>())
                Destroy(item.gameObject.transform.root.GetComponent<Rigidbody>());
            item.gameObject.transform.root.position = cRightHand.transform.position;
            //item.gameObject.transform.root.GetComponent<Collider>().enabled = false;
            //item.gameObject.transform.root.GetComponentInChildren<Collider>().enabled = false;
            //pickingUpItem = true;
            //TODO: rotate
            item.gameObject.transform.root.parent = cRightHand.transform;
            hasItem = true;
            currentItem = item;
        }
    }

    public static Vector3 GetVectorRelativeToObject(Vector3 inputVector, Transform camera)
    {
        Vector3 objectRelativeVector = Vector3.zero;
        if (inputVector != Vector3.zero)
        {
            Vector3 forward = camera.TransformDirection(Vector3.forward);
            forward.y = 0f;
            forward.Normalize();
            Vector3 right = new Vector3(forward.z, 0.0f, -forward.x);

            Vector3 relativeRight = inputVector.x * right;
            Vector3 relativeForward = inputVector.z * forward;

            objectRelativeVector = relativeRight + relativeForward;

            if (objectRelativeVector.magnitude > 1f) objectRelativeVector.Normalize();
        }
        return objectRelativeVector;
    }
}