using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public float speed = 0.5f;
    private Transform target;
    private int waypointIndex;
    public float length = 300f;
    public LayerMask mask;
    void Start()
    {
        speed = 3f;
        waypointIndex = 0;
        target = Waypoints.points[0];  
    }
    void Update()
    {
        Vector3 direction = target.position - transform.position;
        transform.Translate(direction.normalized * speed * Time.deltaTime);

        if (Vector3.Distance(transform.position, target.position) <= 0.1f)
        {
            NextWaypoint();
        }
    }
    void NextWaypoint()
    {
        if(waypointIndex >= Waypoints.points.Length - 1)
        {
            Destroy(gameObject);
            return;
        }
        waypointIndex++;
        target = Waypoints.points[waypointIndex];
    }
}
