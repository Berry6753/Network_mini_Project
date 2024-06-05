using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class OnlineUI : MonoBehaviour
{
    [SerializeField] private TMP_InputField nicknameInputField;
    [SerializeField] private TMP_Text errorText;
    [SerializeField] private GameObject createRoomUI;
    [SerializeField] private GameObject joinRoomUI;

    public void OnClickCreateRoomButton()
    {
        if (nicknameInputField.text != "")
        {
            PlayerSettings.nickname = nicknameInputField.text;
            createRoomUI.SetActive(true);
        }
        else
            StartCoroutine(ShowText());
    }

    public void OnClickJoinRoomButton()
    {
        if (nicknameInputField.text != "")
        {
            PlayerSettings.nickname = nicknameInputField.text;
            joinRoomUI.SetActive(true);
        }
        else
            StartCoroutine(ShowText());
    }

    public void OnClickJoinRoomStartButton()
    {
        var manager = RoomManager.singleton;

        manager.StartClient();
    }

    private IEnumerator ShowText()
    {
        errorText.text = "Please enter your Nickname!";
        yield return new WaitForSeconds(3.0f);
        errorText.text = "";
    }
}
