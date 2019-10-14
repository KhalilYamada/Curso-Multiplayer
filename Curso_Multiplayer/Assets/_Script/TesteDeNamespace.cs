using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun.UtilityScripts;

using Photon.Realtime;
using Photon.Pun;

public class TesteDeNamespace : MonoBehaviour
{

    public Player jogador;


    private void Start()
    {
        jogador.AddScore(1);
    }



}
