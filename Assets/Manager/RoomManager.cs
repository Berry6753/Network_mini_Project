using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class RoomManager : NetworkRoomManager
{
    public override void OnRoomServerConnect(NetworkConnectionToClient conn)
    {
        base.OnRoomServerConnect(conn);

        var spawnPoint = FindObjectOfType<LobbySpawn>().GetSpawnPoint();

        var player = Instantiate(spawnPrefabs[0], spawnPoint, Quaternion.identity, GameObject.Find("GameRoom").transform);
        NetworkServer.Spawn(player, conn);
    }
}
