using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BackGround : MonoBehaviour
{
    private Image background;
    [SerializeField] private Sprite[] backgroundSprites;
    private int spritesIndex = 0;
    private float time;

    private void Awake()
    {
        background = GetComponent<Image>();
        time = 0;
    }

    private void Update()
    {
        BackgroundSpriteSetting();
    }

    private void BackgroundSpriteSetting()
    {
        background.sprite = backgroundSprites[spritesIndex];
        time += Time.deltaTime;
        if (time >= 10.0f)
        {
            spritesIndex++;
            time = 0.0f;
        }
        if (spritesIndex == backgroundSprites.Length)
        {
            spritesIndex = 0;
        }
    }
}
