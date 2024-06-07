using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class GameRoomSettingUI : MonoBehaviour
{
    private bool isReady = false;

    public void ExitGameRoom()
    { 
        var manager = RoomManager.singleton;
        if (manager.mode == Mirror.NetworkManagerMode.Host)
        {
            manager.StopHost();
        }
        else if(manager.mode == Mirror.NetworkManagerMode.ClientOnly)
        {
            manager.StopClient();
        }
    }

    public void ReadyGameRoom()
    {
        var manager = RoomManager.singleton;
        if (manager.mode == Mirror.NetworkManagerMode.ClientOnly)
        {
            if (!isReady)
            {
                PlayerSettings.ReadyImg.SetActive(true);
                isReady = true;
            }
            else
            { 
                PlayerSettings.ReadyImg.SetActive(false);
                isReady = false;
            }
        }
    }
}
