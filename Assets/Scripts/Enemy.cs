using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    private PlayerController playerController;

    // Start is called before the first frame update
    void Start()
    {  
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        playerController = target.GetComponent<PlayerController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si el jugador ha ganado
        if (!playerController.GameIsOver())
        {
            pathfinder.SetDestination(target.position);
        }
        else
        {
            // Si el jugador ha ganado, dejar de seguir
            pathfinder.SetDestination(transform.position);
        }
    }
}
