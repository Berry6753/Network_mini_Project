using Mirror;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeUI : MonoBehaviour
{
    [SerializeField] private Image playerInfo;

    [SerializeField] private List<ColorSelectButton> colorSelectButtons;

    private void OnEnable()
    {
        UpdateColorButton();

        var roomSlots = (NetworkManager.singleton as RoomManager).roomSlots;
        foreach (var player in roomSlots)
        { 
            var aPlayer = player as FeignRoomPlayer;
            if (aPlayer.isLocalPlayer)
            {
                UpdatePreviewColor(aPlayer.playerColor);
                break;
            }
        }
    }

    private void Start()
    {
        var inst = Instantiate(playerInfo);
        playerInfo = inst;
    }

    public void UpdateColorButton()
    {
        var roomSlots = (NetworkManager.singleton as RoomManager).roomSlots;

        for (int i = 0; i < colorSelectButtons.Count; i++)
        {
            colorSelectButtons[i].SetInteractable(true);
        }

        foreach(var player in roomSlots)
        {
            var aPlyaer = player as FeignRoomPlayer;
            colorSelectButtons[(int)aPlyaer.playerColor].SetInteractable(false);
        }
    }

    public void UpdatePreviewColor(EPlayerColor color)
    { 
        playerInfo.color = PlayerColor.GetColor(color);
    }

    public void OnClickColorButton(int index)
    {
        if (colorSelectButtons[index].isInteractable)
        {
            FeignRoomPlayer.MyRoomPlayer.CmdSetPlayerColor((EPlayerColor)index);
            UpdatePreviewColor((EPlayerColor)index);
        }
    }

    public void UpdateSelectColorButton(EPlayerColor color)
    {
        colorSelectButtons[(int)color].SetInteractable(false);
    }

    public void UpdateUnSelectColorButton(EPlayerColor color)
    {
        colorSelectButtons[(int)color].SetInteractable(true);
    }
}
