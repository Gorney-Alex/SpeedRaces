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
            Vector3 roadPositionOld = road.transform.position;
            UpdateBarricadePosition(road.name, roadPositionOld);
            Instantiate(barricade, barricadePosition, Quaternion.Euler(-90f, 0f, 0f));
            Debug.Log("Created Barricade");
        }
    }

    private void UpdateBarricadePosition(string roadName, Vector3 roadPositionOld)
    {
        int randomLocation = Random.Range(0, 2);
        const int length = 100;
        const int height = 14;
        const int width = 6;

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
                barricadePosition = new Vector3(roadPositionOld.x + width, roadPositionOld.y - height, roadPositionOld.z + length);
            }
            else
            {
                barricadePosition = new Vector3(roadPositionOld.x - width, roadPositionOld.y - height, roadPositionOld.z + length);
            }
            break;

            case "2":
            if (randomLocation == 1)
            {
                barricadePosition = new Vector3(roadPositionOld.x + width, roadPositionOld.y + height, roadPositionOld.z + length);
            }
            else
            {
                barricadePosition = new Vector3(roadPositionOld.x - width, roadPositionOld.y + height, roadPositionOld.z + length);
            }
            break;
        }

    }


}
