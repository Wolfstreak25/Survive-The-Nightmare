using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerService : Singleton<PlayerService>
{
    [SerializeField] private PlayerList PlayerObjectList;
    public void PlayerSpawn(int i)
    { 
        PlayerModel PlayerModel = new PlayerModel(PlayerObjectList.Players[i]);
        PlayerController PlayerController = new PlayerController(PlayerModel, PlayerObjectList.Players[i].PlayerView);
    }
    private void Start() {
        PlayerSpawn(0);
    }
}
