using UnityEngine;
using System.Collections.Generic;

public class CreatorBarricades : CreatorRoads
{
    private List<GameObject> roadList;
    [SerializeField] private GameObject barricade;
    private Vector3 barricadePosition;
    void Start()
    {
        roadList = GetRoadList();
        BarricadeCreator();
    }

    private void BarricadeCreator()
    {
        foreach (GameObject road in roadList)
        {
            if (road.name == "0" || road.name == "1" || road.name == "2")
            {
                Vector3 roadPositionOld = road.transform.position;
                UpdateBarricadePosition(road.name, roadPositionOld);
                Instantiate(barricade, barricadePosition, Quaternion.identity);
                Debug.Log("Created Barricade"); 
            }
        }
    }

    private void UpdateBarricadePosition(string roadName, Vector3 roadPositionOld)
    {
        int randomLocation = Random.Range(0, 2);
        const int length = 100;
        const int heightBelow = -12;
        const int heightAbove = 10;
        const int width = 9;

        switch(roadName)
        {
            case "0":
            if (randomLocation == 1)
            {
                barricadePosition = new Vector3(roadPositionOld.x + width, roadPositionOld.y, roadPositionOld.z + length);
            }
            else
            {
                barricadePosition = new Vector3(roadPositionOld.x - width, roadPositionOld.y, roadPositionOld.z + length);
            }
            break;

            case "1":
            if (randomLocation == 1)
            {
                barricadePosition = new Vector3(roadPositionOld.x + width, roadPositionOld.y + heightBelow, roadPositionOld.z + length);
            }
            else
            {
                barricadePosition = new Vector3(roadPositionOld.x - width, roadPositionOld.y + heightBelow, roadPositionOld.z + length);
            }
            break;

            case "2":
            if (randomLocation == 1)
            {
                barricadePosition = new Vector3(roadPositionOld.x + width, roadPositionOld.y + heightAbove, roadPositionOld.z + length);
            }
            else
            {
                barricadePosition = new Vector3(roadPositionOld.x - width, roadPositionOld.y + heightAbove, roadPositionOld.z + length);
            }
            break;

            default:
            break;
        }

    }


}
