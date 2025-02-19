using System.Collections.Generic;
using UnityEngine;

public class CreatorRoads : MonoBehaviour
{
    [HideInInspector] [SerializeField] private GameObject[] roadArrayVersions = new GameObject[5];
    // StraightRoad[0], RoadBelow[1], RoadAbove[2], Road90Twice[3], Road-90Twice[4]
    [HideInInspector] [SerializeField] private int maxRoadsInWorld = 15;

    private static List<GameObject> roadList = new List<GameObject>();
    private Vector3 nextPositionRoad = Vector3.zero;

    private void Start()
    {
        GenerateWorldRoads();
        Debug.Log("Creator is starting");
    }

    public List<GameObject> GetRoadList()
    {
        return roadList;
    }

    private void GenerateWorldRoads()
    {
        CreateRoad(0, 1);

        for (int i = 1; i < maxRoadsInWorld; i++)
        {
            int randomIndex = Random.Range(0, roadArrayVersions.Length);
            CreateRoad(randomIndex, 1);
        }

        CreateRoad(0, 5);
        Debug.Log("Road generation is ended!");
    }

    private void CreateRoad(int index, int count)
    {
        for (int i = 0; i < count; i++)
        {
            GameObject newRoad = Instantiate(roadArrayVersions[index], nextPositionRoad, Quaternion.identity);
            newRoad.name = index.ToString();
            roadList.Add(newRoad);
            UpdateNextPosition(index);
        }
    }

    private void UpdateNextPosition(int roadIndex)
    {
        const float width = 22f;
        const float length = 200f;
        const float length90Twice = 400f;

        switch (roadIndex)
        {
            case 0:
                nextPositionRoad += new Vector3(0f, 0f, length);
                break;
            case 1:
                nextPositionRoad += new Vector3(0f, -width, length);
                break;
            case 2:
                nextPositionRoad += new Vector3(0f, width, length);
                break;
            case 3:
                nextPositionRoad += new Vector3(length90Twice, 0f, length90Twice);
                break;
            case 4:
                nextPositionRoad += new Vector3(-length90Twice, 0f, length90Twice);
                break;
            default:
                Debug.LogError("Неизвестный индекс дороги в UpdateNextPosition");
                break;
        }
    }
}
