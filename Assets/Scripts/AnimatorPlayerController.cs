using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPlayerController : MonoBehaviour
{
    Animator am;
    bool andar = false;
    bool saltar = false;
    
    void Start()
    {
        am = GetComponent<Animator>();
        andar = false;
        saltar = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            Debug.Log("andar arriba");
            andar = true;
            am.SetBool("andar", true);
        }
        
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            Debug.Log("andar abajo");
            andar = true;
            am.SetBool("andar", true);
        }
        
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            Debug.Log("andar izquierda");
            andar = true;
            am.SetBool("andar", true);
        }
        
        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            Debug.Log("andar derecha");
            andar = true;
            am.SetBool("andar", true);
        }
        
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("saltar");
            saltar = false;
            am.SetBool("saltar", true);
        }
        
        
    }
}
