using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Mirror;

public class PlayerSettings : NetworkBehaviour
{
    public static string nickname;

    private TMP_Text nicknameText;
    public static GameObject ReadyImg;

    private void Awake()
    {
        nicknameText = GetComponentInChildren<TMP_Text>();
    }

    private void OnEnable()
    {
        nicknameText.text = nickname;
    }
}
