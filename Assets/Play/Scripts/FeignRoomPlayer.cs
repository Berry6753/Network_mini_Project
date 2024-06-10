using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FeignRoomPlayer : NetworkRoomPlayer
{
    private static FeignRoomPlayer myRoomPlayer;
    public static FeignRoomPlayer MyRoomPlayer
    {
        get 
        {
            if (myRoomPlayer == null)
            { 
                var players = FindObjectsOfType<FeignRoomPlayer>();
                foreach (var player in players)
                {
                    if (player.isOwned)        //player.hasAuthority°¡ ¾ÈµÊ
                    { 
                        myRoomPlayer = player;
                    }
                }
            }
            return myRoomPlayer;
        }
    }

    [SyncVar(hook = nameof(SetPlayerColor_Hook))]
    public EPlayerColor playerColor;

    public void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
    {
        LobbyUIManager.Instance.CustomizeUI.UpdateColorButton();
    }

    public RoomPlayer roomPlayer;

    public void Start()
    {
        base.Start();

        if (isServer)
        {
            SpawnRoomPlayer();
        }
    }

    private void OnDestroy()
    {
        if (LobbyUIManager.Instance != null)
            LobbyUIManager.Instance.CustomizeUI.UpdateUnSelectColorButton(playerColor);
    }

    [Command]
    public void CmdSetPlayerColor(EPlayerColor color)
    {
        playerColor = color;
        roomPlayer.playerColor = color;
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
        player.ownerNetId = netId;
        player.playerColor = color;

        //roomPlayer = player;
    }

    //[ClientRpc]
    //private void SetParentsGameRoom(uint net)
    //{
    //    NetworkClient.spawned[net].transform.SetParent(GameObject.Find("GameRoom").transform, false);
    //}
}
