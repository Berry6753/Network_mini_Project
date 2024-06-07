using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoinRoomUI : MonoBehaviour
{
    public void JoinRoom()
    {
        var manager = RoomManager.singleton;

        manager.StartClient();
    }
}
