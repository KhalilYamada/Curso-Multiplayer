using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class DelayStartLobbyController : MonoBehaviourPunCallbacks
{


    [SerializeField]
    private GameObject delayStartButton; //Botão utilizado para criar e entrar em um jogo
    [SerializeField]
    private GameObject delayCancelButton; //Botão utilizado para parar de procurar uma sala de jogo
    [SerializeField]
    private int RoomSize; //Utilizado para setar manualmente o numero de jogadores de uma sala

    [SerializeField]
    private GameObject botaoModo1;

    bool modo;

    public override void OnConnectedToMaster()
    {
        PhotonNetwork.AutomaticallySyncScene = true;
        delayStartButton.SetActive(true);
        botaoModo1.SetActive(true);
    }


    public void DelayStart()
    {
        delayStartButton.SetActive(false);
        delayCancelButton.SetActive(true);
        //PhotonNetwork.JoinRoom();
        PhotonNetwork.JoinRandomRoom();
        Debug.Log("Delay start");
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to join a room");
        CreateRoom();
    }

    void CreateRoom()
    {
        Debug.Log("Creating room now");
        int randomRoomNumber = Random.Range(0, 10000);
        RoomOptions roomOps = new RoomOptions() { IsVisible = true, IsOpen = true, MaxPlayers = (byte)RoomSize };
        PhotonNetwork.CreateRoom("Room" + randomRoomNumber, roomOps);
        Debug.Log(randomRoomNumber);
    }

    public override void OnCreateRoomFailed(short returnCode, string message)
    {
        Debug.Log("Failed to create a room... trying again");
        CreateRoom();
    }

    public void DelayCancel()
    {
        delayCancelButton.SetActive(false);
        delayStartButton.SetActive(true);
        PhotonNetwork.LeaveRoom();
    }
}

