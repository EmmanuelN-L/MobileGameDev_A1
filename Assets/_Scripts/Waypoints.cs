using UnityEngine;

public class Waypoints : MonoBehaviour
{
    public static Transform[] points;
    //This adds the children's (waypoints) to the array
    void Awake ()
    {
        points = new Transform[transform.childCount];
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }

}
