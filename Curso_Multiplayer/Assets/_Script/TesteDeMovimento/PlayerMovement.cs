using Photon.Pun;
using Photon.Realtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerMovement : MonoBehaviourPunCallbacks
{
    public bool devTesting = false;

    public PhotonView pView;

    public GameObject playerCam;

    [SerializeField]
    private int moveSpeed;
	[SerializeField]
	private float jumpPower;
	[SerializeField]
	private int gravity;
	


	private float gravityForce;

	
    private Vector3 selfPos;

    private GameObject sceneCam;

    public void Awake()
    {
        if (!devTesting && pView.IsMine)
        {
            sceneCam = GameObject.Find("MainCamera");
            sceneCam.SetActive(false);
            playerCam.SetActive(true);
        }
        
    }

    void Update()
    {
		if (!pView.IsMine) return;

		
            CheckInput();
        


    }

	
    private void CheckInput()
    {
		if (isGrounded())
		{
			gravityForce = 0;

			if (Input.GetButtonDown("Jump"))
			{
				gravityForce = jumpPower;
			}
		}
		else
		{
			gravityForce -= gravity * Time.deltaTime;
		}

		transform.Translate(moveSpeed * Input.GetAxis("Horizontal") * Time.deltaTime, 0f, moveSpeed * Input.GetAxis("Vertical") * Time.deltaTime);


	}


	
	private bool isGrounded()
	{
		RaycastHit hit;
		if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.down), out hit, 1000))
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * hit.distance, Color.yellow);
			//Debug.Log("Did Hit");

			if (hit.distance <= 1f)
			{
				
				return true;
			}

			else
			{
				if (hit.distance < 1f + (-gravityForce * Time.deltaTime))
				{
					gravityForce = hit.distance;
					transform.position = new Vector3(transform.position.x, hit.point.y + 1, transform.position.z);
				}
				return false;
			}

		}
		else
		{
			Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.down) * gravityForce, Color.white);
		//	Debug.Log("Did not Hit");
			return false;
		}
	}
	



    

	
}
