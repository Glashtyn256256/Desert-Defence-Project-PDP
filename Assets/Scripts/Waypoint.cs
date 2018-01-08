using UnityEngine;

public class Waypoint : MonoBehaviour
{

    public static Transform[] path1points;
    public static Transform[] path2points;
    public int path;

    void Awake()
    {
        if (path == 1)
        {
            path1points = new Transform[transform.childCount];

            for (int i = 0; i < path1points.Length; i++)
            {
                path1points[i] = transform.GetChild(i);
            }
        }

        if (path == 2)
        {
            path2points = new Transform[transform.childCount];

            for (int i = 0; i < path2points.Length; i++)
            {
                path2points[i] = transform.GetChild(i);
            }
        }
    }
}
