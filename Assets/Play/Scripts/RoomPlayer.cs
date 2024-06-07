using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class RoomPlayer : NetworkRoomPlayer
{
    private Image playerInfoImg;

    [SyncVar(hook = nameof(SetPlayerColor_Hook))]
    public EPlayerColor playerColor;

    public void SetPlayerColor_Hook(EPlayerColor oldColor, EPlayerColor newColor)
    {
        if (playerInfoImg == null)
        {
            playerInfoImg = GetComponentInChildren<Image>();
        }
        playerInfoImg.color = PlayerColor.GetColor(newColor);
    }

    private void Start()
    {
        playerInfoImg = GetComponentInChildren<Image>();
        playerInfoImg.color = PlayerColor.GetColor(playerColor);
    }

    private void DefaultPlayerColor()
    {
        var roomslots = (NetworkManager.singleton as RoomManager).roomSlots;
        EPlayerColor color = EPlayerColor.White;
        for (int i = 0; i < (int)EPlayerColor.Lime + 1; i++)
        { 
            bool isFindSameColor = false;
            foreach (var roomPlayer in roomslots) 
            { 
                var thisRoomPlayer = roomPlayer as RoomPlayer;
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

        //Vector3 spawnPos = FindObjectOfType(S)
    }
}
