using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeignRoomPlayer : NetworkRoomPlayer
{
    [SyncVar]
    public EPlayerColor playerColor;

    public void Start()
    {
        base.Start();

        if (isServer)
        { 
            SpawnRoomPlayer();
        }
    }

    private void SpawnRoomPlayer()
    {
        var roomslots = (NetworkManager.singleton as RoomManager).roomSlots;
        EPlayerColor color = EPlayerColor.White;
        for (int i = 0; i < (int)EPlayerColor.Lime + 1; i++)
        {
            bool isFindSameColor = false;
            foreach (var roomPlayer in roomslots)
            {
                var thisRoomPlayer = roomPlayer as FeignRoomPlayer;
                if (thisRoomPlayer.playerColor == (EPlayerColor)i && roomPlayer.netId != netId)
                {
                    isFindSameColor = true;
                    break;
                }
            }

            if (!isFindSameColor)
            {
                color = (EPlayerColor)i;
                break;
            }
        }
        playerColor = color;

        var spawnPoint = FindObjectOfType<LobbySpawn>().GetSpawnPoint();

        var player = Instantiate(RoomManager.singleton.spawnPrefabs[0], spawnPoint, Quaternion.identity, GameObject.Find("GameRoom").transform).GetComponent<RoomPlayer>();
        NetworkServer.Spawn(player.gameObject, connectionToClient);
        player.playerColor = color;
    }
}
