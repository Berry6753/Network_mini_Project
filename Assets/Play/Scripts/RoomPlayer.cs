using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;
using UnityEngine.UI;

public class RoomPlayer : NetworkBehaviour
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
}
