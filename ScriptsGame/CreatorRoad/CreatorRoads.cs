// Gorney-Alex code

using System.Collections.Generic;
using UnityEngine;

public class CreatorRoads : MonoBehaviour
{
    [SerializeField] private int maxRoadsInWorld = 15;
    [SerializeField] private GameObject[] roadArrayVersions = new GameObject[5];
    // StraightRoad[0], RoadBelow[1], RoadAbove[2], Road90Twice[3], Road90[4]

    private List<GameObject> roadList = new List<GameObject>();

    private Vector3 nextPositionRoad = new Vector3(0f, 0f, 0f);

    private bool isMaxRoadReached = false;


    private void Start()
    {
        CreateOneStarightRoad();
    }

    private void Update()
    {   
        if (!isMaxRoadReached)
        {
            if (MaxCountRoads()) 
            {
                isMaxRoadReached = true;
                CreatorTheLast5Roads();
                Debug.Log("Max count of roads reached!");
            } 
            else {
                CreateRandomRoads();
            }
        }
    }

    private void CreateOneStarightRoad()
    {
        GameObject newRoad = Instantiate(roadArrayVersions[0], nextPositionRoad, Quaternion.identity);
        newRoad.name = "0";
        roadList.Add(newRoad);
        DistanceDeterminationZ();
    }

    private void CreatorTheLast5Roads()
    {
        for(int i = 0; i < 5; i++)
        {
            CreateOneStarightRoad();
        }
    }

    private void CreateRandomRoads()
    {
        int randomIndexRoad = Random.Range(0, 5);
        GameObject newRoad = Instantiate(roadArrayVersions[randomIndexRoad], nextPositionRoad, Quaternion.identity);
        newRoad.name = randomIndexRoad.ToString();
        roadList.Add(newRoad);
        DistanceDeterminationZ();
    }

    private void DistanceDeterminationZ()
    {
        float width = 22f;
        float length = 200f;
        float length90Twice = 400f;

        GameObject lastRoad = roadList[roadList.Count - 1];

        switch (lastRoad.name)
        {
            case "0":
                nextPositionRoad += new Vector3(0f, 0f, length);
                break;
            case "1":
                nextPositionRoad += new Vector3(0f, -width, length);
                break;
            case "2":
                nextPositionRoad += new Vector3(0f, width, length);
                break;
            case "3":
                nextPositionRoad += new Vector3(length90Twice, 0f, length90Twice);
                break;
            case "4":
                nextPositionRoad += new Vector3(-length90Twice, 0f, length90Twice);
                break;
            default:
                Debug.Log("error in DistanceDeterminationZ");
                break;
        }
    }

    private bool MaxCountRoads()
    {
        if(roadList.Count >= maxRoadsInWorld) { return true; }
        return false;
    }
}