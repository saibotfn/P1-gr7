using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Input system library

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; //Gemmer den vector der kommer n�r brugeren trykker p� WASD
    private Rigidbody2D myBody; //Gemmer den Rigigdbody vi flytter rundt p�
    private Animator myAnimator; //En animator s� man kan interagere med den i koden

    [SerializeField] private int speed = 5; //S�tter hastighed som charateren flytter sig med

    private void Awake() //Awake k�rer n�r programmet starter lidt ala start men anderledes
    {
        myBody = GetComponent<Rigidbody2D>(); //S�tter myBody rigidbody til den samme rigidbody som den gameobject den sidder p�
        myAnimator = GetComponent<Animator>(); //animator til den animator der sidder p� gameobejectet
    }

    private void OnMovement(InputValue value) //En funktion der holder �je med den value der kommer fra input
    {
        movement = value.Get<Vector2>(); //Movement bliver sat til den vector2 der kommer n�r man trykker p� wasd

        if (movement.x != 0 || movement.y != 0) {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);
        }

    }

    private void FixedUpdate()// mere optimal version af update til vores form�l
    {
        myBody.velocity = movement * speed; //S�tter velocity af rigidbody til den hastighed der er bestemt ved speed
    }
}
