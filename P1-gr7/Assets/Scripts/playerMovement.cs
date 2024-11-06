using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem; //Input system library

public class playerMovement : MonoBehaviour
{
    private Vector2 movement; //Gemmer den vector der kommer når brugeren trykker på WASD
    private Rigidbody2D myBody; //Gemmer den Rigigdbody vi flytter rundt på
    private Animator myAnimator; //En animator så man kan interagere med den i koden

    [SerializeField] private int speed = 5; //Sætter hastighed som charateren flytter sig med

    private void Awake() //Awake kører når programmet starter lidt ala start men anderledes
    {
        myBody = GetComponent<Rigidbody2D>(); //Sætter myBody rigidbody til den samme rigidbody som den gameobject den sidder på
        myAnimator = GetComponent<Animator>(); //animator til den animator der sidder på gameobejectet
    }

    private void OnMovement(InputValue value) //En funktion der holder øje med den value der kommer fra input
    {
        movement = value.Get<Vector2>(); //Movement bliver sat til den vector2 der kommer når man trykker på wasd

        if (movement.x != 0 || movement.y != 0) {
            myAnimator.SetFloat("x", movement.x);
            myAnimator.SetFloat("y", movement.y);
        }

    }

    private void FixedUpdate()// mere optimal version af update til vores formål
    {
        myBody.velocity = movement * speed; //Sætter velocity af rigidbody til den hastighed der er bestemt ved speed
    }
}
