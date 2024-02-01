using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    // Velocidad a la que se mueve el jugador.
    public float speed = 0;

    // Rigidbody del jugador.
    private Rigidbody rb;

    // Movimiento a lo largo de los ejes X e Y.
    private float movementX;
    private float movementY;

    // Start se llama antes de la primera actualización de fotograma.
    void Start()
    {
        // Obtener y almacenar el componente Rigidbody adjunto al jugador.
        rb = GetComponent<Rigidbody>();

        Debug.Log("Hola, soy un mensaje de debug en el Start");
    }

    // Dar un salto con la tecla Fire(boton izquierdo del mouse)
    void OnFire()
    {
        Debug.Log("Hola, soy un mensaje de debug en OnFire");

        //aplico fuerza al rigidbody
        rb.AddForce(Vector3.up * 5.0f, ForceMode.Impulse);
    }

    // Esta función se llama cuando se detecta una entrada de movimiento.
    void OnMove(InputValue movementValue)
    {
        // Convertir el valor de entrada en un Vector2 para el movimiento.
        Vector2 movementVector = movementValue.Get<Vector2>();

        // Almacenar los componentes X e Y del movimiento.
        Debug.Log("X");
        movementX = movementVector.x;
        Debug.Log("Y");
        movementY = movementVector.y;
    }



    // FixedUpdate is called once per fixed frame-rate frame.
    private void FixedUpdate()
    {
        // Crear un vector de movimiento 3D utilizando las entradas X e Y.
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);

        //Debug.Log("Estoy en el FixedUpdate");

        // Aplicar fuerza al Rigidbody para mover al jugador.
        rb.AddForce(movement * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }

    }
}
