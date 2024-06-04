using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private List<Button> killerCountButtons;
    [SerializeField] private List<Button> maxiumNumCountButtons;

    private CreateRoomData roomData;

    private void Awake()
    {
        foreach (Button button in killerCountButtons)
        { 
            button.onClick.AddListener(() => OnButtonClick(killerCountButtons));
        }
        foreach (Button button in maxiumNumCountButtons)
        {
            button.onClick.AddListener(() => OnButtonClick(maxiumNumCountButtons));
        }
    }

    private void OnButtonClick(List<Button> buttons)
    {
        throw new NotImplementedException();
    }

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(killerCountButtons[0].gameObject);
        EventSystem.current.SetSelectedGameObject(maxiumNumCountButtons[0].gameObject);
        roomData = new CreateRoomData() { killerCount = 1, maxiumNumCount = 4 };
    }

    public void UpdateKillerCount(int count)
    {
        roomData.killerCount = count;

        int limitMax = count == 1 ? 4 : 7;
        if (roomData.maxiumNumCount < limitMax)
        {
            UpdateMaxiumNumCount(limitMax);
            EventSystem.current.SetSelectedGameObject(maxiumNumCountButtons[limitMax-4].gameObject);
        }
        else
            UpdateMaxiumNumCount(roomData.maxiumNumCount);

        for (int i = 0; i < maxiumNumCountButtons.Count; i++)
        {
            if (i < limitMax - 4)
                maxiumNumCountButtons[i].interactable = false;
            else
                maxiumNumCountButtons[i].interactable = true;
        }
    }

    public void UpdateMaxiumNumCount(int count)
    {
        roomData.maxiumNumCount = count;
    }
}

public class CreateRoomData
{
    public int killerCount;
    public int maxiumNumCount;
}
