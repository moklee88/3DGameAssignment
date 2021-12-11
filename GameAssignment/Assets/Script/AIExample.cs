using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.AI;

public class AIExample : MonoBehaviour
{
    public enum WanderType { Random, Waypoint};

    public WanderType wanderType = WanderType.Random;
    public FirstPersonController fpsc;
    public float fov = 120f;
    public float viewDistance = 10f;
    public float wanderRadius = 10f;
    public Transform[] waypoints; //Array of waypoints is only used when waypoint is selected

    public Vector3 wanderPoint;
    private bool isAware = false;
    private Renderer renderer;
    private NavMeshAgent agent;
    private int waypointIndex = 0;


    public void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        renderer = GetComponent<Renderer>();
        wanderPoint = RandomWanderPoint();
    }
    // Update is called once per frame
    public void Update()
    {
        if (isAware)
        {
            agent.SetDestination(fpsc.transform.position);
            renderer.material.color = Color.red;
        }
        else
        {
            SearchPlayer();
            Wander();
            renderer.material.color = Color.blue;
        }
    }

    public void SearchPlayer()
    {
        if(Vector3.Angle(Vector3.forward, transform.InverseTransformPoint(fpsc.transform.position)) < fov / 2f)
        {
            if (Vector3.Distance(fpsc.transform.position, transform.position) < viewDistance) 
            {
                RaycastHit hit;
                if (Physics.Linecast(transform.position, fpsc.transform.position, out hit, -1)) 
                {
                    if (hit.transform.CompareTag("Player"))
                    {
                        OnAware();
                    }
                    
                }
                
            }
        }
    }

    public void OnAware()
    {
        isAware = true;
    }

    public void Wander()
    {
        if (wanderType == WanderType.Random)
        {
            if (Vector3.Distance(transform.position, wanderPoint) < 2f)
            {
                wanderPoint = RandomWanderPoint();
            }
            else
            {
                agent.SetDestination(wanderPoint);
            }
        }
        else
        {
            //waypoint wandering
            if (Vector3.Distance(waypoints[waypointIndex].position, transform.position) < 3f)
            {
                if (waypointIndex == waypoints.Length - 1)
                {
                    waypointIndex = 0;

                }
                else
                {
                    waypointIndex++;
                }

            }
            else
            {
                agent.SetDestination(waypoints[waypointIndex].position);
            }
        }

    }

    public Vector3 RandomWanderPoint()
    {
        Vector3 randomPoint = (Random.insideUnitSphere * wanderRadius) + transform.position;
        NavMeshHit navHit;
        NavMesh.SamplePosition(randomPoint, out navHit, wanderRadius, -1);
        return new Vector3(navHit.position.x, transform.position.y, navHit.position.z);
    }
}
