using Photon.Pun;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DelayStartRoomController : MonoBehaviourPunCallbacks
{

    [SerializeField]
    private string waitingRoomSceneIndexA;
    [SerializeField]
    private string waitingRoomSceneIndexB;


    private bool modo;

    [SerializeField]
    private GameObject botaoModo1;
    [SerializeField]
    private GameObject botaoModo2;


    public override void OnEnable()
    {
        PhotonNetwork.AddCallbackTarget(this);
    }

    public override void OnDisable()
    {
        PhotonNetwork.RemoveCallbackTarget(this);
    }

    public override void OnJoinedRoom()
    {
        if(modo == false)
        {
            SceneManager.LoadScene(waitingRoomSceneIndexA);
        }
        else
        {
            SceneManager.LoadScene(waitingRoomSceneIndexB);
        }
    }

    public void SwichMode()
    {
        if (modo == true)
        {
            modo = false;
            botaoModo1.SetActive(true);
            botaoModo2.SetActive(false);
        }
        else
        {
            modo = true;
            botaoModo1.SetActive(false);
            botaoModo2.SetActive(true);
        }
    }
}