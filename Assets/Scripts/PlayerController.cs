using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public bool AllowMovement;
    public float speed;

    private Rigidbody m_rigidbody;
    private Vector3 m_moveDirection = Vector3.zero;
    private Transform m_transform;

    [SerializeField]
    private LayerMask m_layerMask;

    public float turnSpeed;

    [SerializeField]
    private GameObject moodIcon;

    void Awake()
    {
        m_transform = transform;
        m_rigidbody = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if (AllowMovement)
            DoMovement();
    }
    /// <summary>
    /// Do player movement
    /// </summary>
    void DoMovement()
    {
        m_rigidbody.velocity = Vector3.zero;
        Vector3 dist = m_moveDirection;

        m_moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
        m_moveDirection = m_transform.TransformDirection(m_moveDirection);
        m_moveDirection *= speed;

        m_rigidbody.velocity = dist;
    }

    public void DisplayMood()
    {
        StartCoroutine(ShowMood());
    }

    private IEnumerator ShowMood()
    {
        moodIcon.SetActive(true);
        yield return new WaitForSeconds(2);
        moodIcon.SetActive(false);
    }
}