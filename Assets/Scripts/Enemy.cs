using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    private NavMeshAgent pathfinder;
    private Transform target;
    private PlayerController playerController;
    private Animator ballAnimator; // No necesitas el Animator de la bola en el script del enemigo

    public float alertDistance = 5f;

    // Start is called before the first frame update
    void Start()
    {
        pathfinder = GetComponent<NavMeshAgent>();
        target = GameObject.Find("Player").transform;
        playerController = target.GetComponent<PlayerController>();
        // No necesitas obtener el Animator de la bola aquí
    }

    // Update is called once per frame
    void Update()
    {
        // Verificar si el jugador ha ganado
        if (!playerController.GameIsOver())
        {
            pathfinder.SetDestination(target.position);

            // Verificar si el jugador está cerca del enemigo
            if (Vector3.Distance(transform.position, target.position) < alertDistance)
            {
                // Realiza acciones de alerta aquí
            }
        }
        else
        {
            // Si el jugador ha ganado, dejar de seguir
            pathfinder.SetDestination(transform.position);
        }
    }
}

