using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreatorRoads : MonoBehaviour
{
    [SerializeField] private GameObject[] roadArrayVersions = new GameObject[5];
    // StraightRoad[0], RoadBelow[1], Road90[2], Road90Twice[3], RoadAbove[4]

    private List<GameObject> roadList = new List<GameObject>();


    private Vector3 nextPositionRoad = new Vector3(0, 0, 0);
    private int width = 100;
    private int height = 200;
    private int maxRoads = 5;


    private void Start()
    {
        CreateRoad();
    }

    private void Update()
    {
        
    }

    private void CreateRoad()
    {
        for (int i = 0; i < maxRoads; i++)
        {
            GameObject newRoad = Instantiate(roadArrayVersions[i], nextPositionRoad, Quaternion.Euler(0, 0, 0));
            nextPositionRoad += new Vector3(0, 0, height);
        }
    }
}
