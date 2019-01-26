using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public GameObject pickedUpImg;

    public static GameManager GM;

    private PlayerController m_pc;

    public int currentScene;

    private void Awake()
    {
        GM = this;
        m_pc = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        /*if (Input.GetKeyDown(KeyCode.E))
            m_pc.DisplayMood();*/
    }

    public void ShowPickupImg(Sprite sp)
    {
        pickedUpImg.GetComponent<Image>().sprite = sp;
        StartCoroutine(showImg());
    }

    private IEnumerator showImg()
    {
        //TODO: add cool effect :)
        pickedUpImg.gameObject.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        pickedUpImg.gameObject.SetActive(false);
    }

    public void ShowInteractImg(Sprite sp)
    {
        pickedUpImg.GetComponent<Image>().sprite = sp;

        if (pickedUpImg.gameObject.activeSelf)
            pickedUpImg.gameObject.SetActive(false);
        else
            pickedUpImg.gameObject.SetActive(true);
        
    }
}
