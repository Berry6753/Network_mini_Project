using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Mirror;

public class CreateRoomUI : MonoBehaviour
{
    [SerializeField] private List<Button> killerCountButtons;
    [SerializeField] private List<Button> maxiumNumCountButtons;

    private CreateRoomData roomData;

    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(killerCountButtons[0].gameObject);
        EventSystem.current.SetSelectedGameObject(maxiumNumCountButtons[0].gameObject);
        roomData = new CreateRoomData() { killerCount = 1, maxiumNumCount = 4 };
    }

    public void UpdateKillerCount(int count)
    {
        roomData.killerCount = count;

        for (int i = 0; i < killerCountButtons.Count; i++)
        {
            if (i == count - 1)
                killerCountButtons[i].image.color = new Color(1f, 0f, 0f, 1f);
            else
                killerCountButtons[i].image.color = new Color(1f, 0f, 0f, 0f);
        }

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
            {
                maxiumNumCountButtons[i].GetComponentInChildren<TMP_Text>().color = new Color(1f, 1f, 1f, 0.5f);
                maxiumNumCountButtons[i].interactable = false;
            }
            else
            {
                maxiumNumCountButtons[i].interactable = true;
                maxiumNumCountButtons[i].GetComponentInChildren<TMP_Text>().color = new Color(1f, 1f, 1f, 1f);
            }
        }
    }

    public void UpdateMaxiumNumCount(int count)
    {
        roomData.maxiumNumCount = count;

        for (int i = 0; i < maxiumNumCountButtons.Count; i++)
        {
            if (i == count - 4)
                maxiumNumCountButtons[i].image.color = new Color(1f, 0f, 0f, 1f);
            else
                maxiumNumCountButtons[i].image.color = new Color(1f, 0f, 0f, 0f); 
        }
    }

    public void CreateRoom()
    {
        var manager = RoomManager.singleton;

        manager.StartHost();
    }
}

public class CreateRoomData
{
    public int killerCount;
    public int maxiumNumCount;
}
