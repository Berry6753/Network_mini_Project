using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class CharacterMove : NetworkBehaviour
{
    [SyncVar] private float speed = 2.0f;

    [SyncVar] public EPlayerColor playerColor;

    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.material.SetColor("_PlayerColor", PlayerColor.GetColor(playerColor));
    }
}
