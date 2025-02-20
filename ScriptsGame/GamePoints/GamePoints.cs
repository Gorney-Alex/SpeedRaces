using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePoints : CreatorRoads
{
    private List<GameObject> roadList;
    [SerializeField] private GameObject barricade;
    private Vector3 pointPosition;
    void Start()
    {
        roadList = GetRoadList();
    }
}
