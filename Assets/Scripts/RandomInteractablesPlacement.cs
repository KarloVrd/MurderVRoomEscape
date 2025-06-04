using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInteractablesPlacement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // array of points in the scene
        Vector3[] points = new Vector3[]
        {
            new Vector3(-4.65299988f, 0.244000003f, -3.21967888f),
            new Vector3(-2.98900008f, 0.244000003f, -3.21967888f),
            new Vector3(0.0520000011f, 0.158000007f, -2.92400002f),
            new Vector3(0.470999986f, 0.158000007f, 0.549000025f),
            new Vector3(-1.91299999f, 0.141000003f, 3.4849999f),
            new Vector3(-1.50199997f, 1.11199999f, 2.8599999f), 
            new Vector3(-9.81099987f,0.150000006f,3.44700003f),
            new Vector3(0.317999989f, 0, 0.490999997f),
        };

        // grab children of this game object and place them at random points,
        // points must be different for each child
        for (int i = 0; i < transform.childCount; i++)
        {
            // get a random point from the array
            int randomIndex = Random.Range(0, points.Length);
            Vector3 randomPoint = points[randomIndex];

            // set the position of the child
            Transform child = transform.GetChild(i);
            child.position = randomPoint;

            // remove the point from the array so it can't be used again
            List<Vector3> pointList = new List<Vector3>(points);
            pointList.RemoveAt(randomIndex);
            points = pointList.ToArray();
        }

    }
}
