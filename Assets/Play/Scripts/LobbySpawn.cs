using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbySpawn : MonoBehaviour
{
    [SerializeField] private RectTransform[] points;

    private int index;

    public Vector3 GetSpawnPoint()
    {
        //Vector3[] pos = new Vector3[points.Length];
        //for (int i = 0; i > points.Length; i++)
        //{
        //    pos[i] = points[i].position;
        //}
        //foreach(Vector3 point in pos)
        //{

        //}
        Vector3 point = points[index++].position;
        if (index >= points.Length)
            index = points.Length - 1;
        return point;
    }
}
