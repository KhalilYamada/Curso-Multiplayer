using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public bool devTesting = false;

    public PhotonView photonView;

    public GameObject playerCam;

    [SerializeField]
    private int moveSpeed;

    private Vector3 selfPos;

    private GameObject sceneCam;

    public void Awake()
    {
        if (!devTesting && photonView.IsMine)
        {
            sceneCam = GameObject.Find("MainCamera");
            sceneCam.SetActive(false);
            playerCam.SetActive(true);
        }
        
    }

    void Update()
    {
        if (!devTesting)
        {
            if (photonView.IsMine)
            {
                Debug.Log("check input 1");
                CheckInput();
            }
            else
            {
                Debug.Log("smooth Movement");
                SmoothNetMovement();
            }
        }
        else
        {
            Debug.Log("check input 2");
            CheckInput();
        }
    }

    private void CheckInput()
    {
        transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);
    }

    private void SmoothNetMovement()
    {
        transform.position = Vector3.Lerp(transform.position, selfPos, Time.deltaTime * 8);
    }
}
