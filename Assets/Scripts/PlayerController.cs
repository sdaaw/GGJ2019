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

    [SerializeField]
    private GameObject moodIcon;

    public bool hasItem;
    public Item currentItem;

    public void SetCharacter(int id)
    {
        for(int i = 0; i < players.Count; i++)
        {
            if (i == id)
            {
                if (cRightHand != null && cRightHand.transform.GetChild(0))
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
        animator.SetFloat("speed", m_rigidbody.velocity.magnitude);
        //Debug.Log(m_rigidbody.velocity.magnitude);
        if (moodIcon != null)
            moodIcon.transform.LookAt(m_playerCamera.transform);
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

    public void DisplayMood(Sprite img)
    {
        moodIcon.GetComponentInChildren<Image>().sprite = img;
        StartCoroutine(ShowMood());
    }

    private IEnumerator ShowMood()
    {
        moodIcon.SetActive(true);
        yield return new WaitForSeconds(2);
        moodIcon.SetActive(false);
    }

    public void PutItemToHand(Item item)
    {
        if(!hasItem)
        {
            Destroy(item.gameObject.transform.root.GetComponentInChildren<Rigidbody>());
            item.gameObject.transform.root.position = cRightHand.transform.position;
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