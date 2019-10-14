using Photon.Pun;
using Photon.Realtime;
using Photon.Pun.UtilityScripts;

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coletavel : MonoBehaviour
{
    PhotonView playerView;
    Player player;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerView = other.GetComponent<PhotonView>();
            if (playerView.IsMine == true && playerView.IsMine != null)
            {
                PlayerMovement jogador = other.GetComponent<PlayerMovement>();

                jogador.pView.Owner.AddScore(1);

                //jogador.player.AddScore(1);
                Destroy(gameObject);
            }
        }
    }
}
