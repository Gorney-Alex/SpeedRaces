using System.Collections.Generic;
using UnityEngine;

public class CreatorPoints : CreatorRoads
{
    private List<GameObject> roadList;
    private Vector3 pointPosition;
    [SerializeField] private GameObject pointModel;

    private void Start()
    {
        roadList = GetRoadList();
        CreatePoints();
    }

    private void CreatePoints()
    {
        foreach(GameObject road in roadList)
        {
            Vector3 roadOldPosition = road.transform.position;
            UpdatePointPosition(road.name, roadOldPosition);
            Instantiate(pointModel, pointPosition, Quaternion.identity);
            Debug.Log("Points are created");
        }
    }

    private void UpdatePointPosition(string roadName, Vector3 roadOldPosition)
    {
        const int length = 50;
        const int heightBelow = -5;
        const int heightAbove = 5;
        const int width = 200;

        switch(roadName)
        {
            case "0":
            pointPosition = new Vector3(roadOldPosition.x, roadOldPosition.y, roadOldPosition.z + length);
            break;

            case "1":
            pointPosition = new Vector3(roadOldPosition.x, roadOldPosition.y + heightBelow, roadOldPosition.z + length);
            break;

            case "2":
            pointPosition = new Vector3(roadOldPosition.x, roadOldPosition.y + heightAbove, roadOldPosition.z + length);
            break;

            case "3":
            pointPosition = new Vector3(roadOldPosition.x + width, roadOldPosition.y, roadOldPosition.z + length*4);
            break;

            case "4":
            pointPosition = new Vector3(roadOldPosition.x + (-width), roadOldPosition.y, roadOldPosition.z + length*4);
            break;

            default:
            Debug.LogWarning($"Неизвестное имя дороги: {roadName}");
            break;
        }
    }
}
