# Tarea: Unity Movimientos
--------------------------
## Enunciado
Realiza el comienzo del "juego roll a ball", hasta tener el Player moviendose y la cámara siguiendolo.

Realiza modificaciones en el código para que:

1. El Player se mueva de una manera diferente, prueba a cambiar parámetros del rigibody, la fórmula de la fuerza que se aplica, etc.
2. La cámara haga un seguimiento diferente al Player, como sería en primera persona? Que otro seguimiento se te ocurre
3. La cámara se mueve independientemente del Player, ¿como sería que la cámara se moviera alrededor de la mesa?

Entregar el repositorio solo con los scripts del Player y de la Cámara.

---------------------------
## Primer Cambio: El Player se mueva de una manera diferente, prueba a cambiar parámetros del rigibody, la fórmula de la fuerza que se aplica, etc.
```
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 5.0f; // Velocidad a la que se mueve el jugador.
    public float jumpForce = 8.0f; // Fuerza del salto.

    private Rigidbody rb;
    private float movementX;
    private float movementY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Debug.Log("Hola, soy un mensaje de debug en el Start");
    }

    void OnFire()
    {
        Debug.Log("Hola, soy un mensaje de debug en OnFire");
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        movementX = movementVector.x;
        movementY = movementVector.y;
    }

    private void FixedUpdate()
    {
        Vector3 movement = new Vector3(movementX, 0.0f, movementY);
        rb.AddForce(movement * speed);

        // Limitar la velocidad del jugador para que no sea demasiado rápido.
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
        }
    }
}

```
En este código, he agregado una nueva variable jumpForce que controla la fuerza del salto. 
Al llamar a **rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);** en el método **OnFire()**, el jugador aplicará una fuerza más fuerte hacia arriba al saltar.<br> 
También he agregado una limitación a la velocidad del jugador para evitar que se vuelva demasiado rápido.

---------------------------
## Segundo Cambio: La cámara haga un seguimiento diferente al Player, como sería en primera persona?

1. Selecciono la cámara principal.
2. Establezco el valor de la posición Y en 1, para que esté justo arriba del Jugador. 
3. Establezco el valor de rotación X, Y, Z en 0.
4. Obtengo una vista previa del ángulo de la cámara en la vista Juego.
