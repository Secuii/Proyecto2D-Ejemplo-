using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variables necesarias
    [Header("Movement")]
    [SerializeField] private float playerMaxSpeed = 4f;
    [SerializeField] private float playerAcceleratioToMax = 0.4f;
    [SerializeField] private float xPos = 0;

    private float playerAccelerationPerSec = 0;


    [Header("Jump")]
    [SerializeField] private float MaxJump = 1.5f;
    [SerializeField] private float timeReachMaxJump = 0f;
    [SerializeField] private float yPos = 0f;

    private float verticalMovement = 0f;

    [Header("Set")]
    [SerializeField] private float characterGravity = 9.8f;
    [SerializeField] private float distanceCheckGround = 0f;
    [SerializeField] private LayerMask groundMask;
    [SerializeField] private float gravityFallMultiplier = 0f;
    [SerializeField] private Collider2D boxCollider2D = null;
    private bool CharacterIsJumping = false;


    void Start()
    {
        //Calculo de la aceleracion
        verticalMovement = MaxJump / timeReachMaxJump;

        playerAccelerationPerSec = playerMaxSpeed / playerAcceleratioToMax;
    }

    //Time.deltaTime es el tiempo entre frames para hacer que un pc que tira mas frame o menos frame no afecte
    //a la velocidad del juego

    void Update()
    {
        CharacterPhysic();
        //Siempre y cuando la tecla "A" este presionada
        if (Input.GetKey(KeyCode.A))
        {
            //Comprobamos si mi velocidad es mayor a mi maxima velocidad en negativo
            if(xPos > -playerMaxSpeed)
            {
                //añado el valor de mi aceleracion a mi velocidad
                xPos -= playerAccelerationPerSec * Time.deltaTime;
            }
        }
        //Lo mismo en positivo
        if (Input.GetKey(KeyCode.D))
        {
            if (xPos < playerMaxSpeed)
            {
                xPos += playerAccelerationPerSec * Time.deltaTime;
            }
        }

        if (Input.GetKeyUp(KeyCode.A) || Input.GetKeyUp(KeyCode.D))
        {
            xPos = 0;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            CharacterIsJumping = true;
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            CharacterIsJumping = false;
        }
        Jump();

        //Muevo a mi personaje con un vector 2 nuevo el cual sera mi velocidad y mi posicion actual en Y 
        transform.Translate(new Vector2(xPos, yPos) * Time.deltaTime);
    }

    private void CharacterPhysic()
    {
        if (CheckGround())
        {
            yPos = 0;
        }
        else
        {
            if (!CharacterIsJumping)
            {
                yPos += characterGravity * Time.deltaTime;
            }
        }
    }

    private bool CheckGround()
    {
        RaycastHit2D hit = Physics2D.BoxCast(boxCollider2D.bounds.center, boxCollider2D.bounds.size, 0f, Vector2.down, distanceCheckGround, groundMask);
        return hit.collider != null;
    }

    private void Jump()
    {
        if (yPos < MaxJump && CharacterIsJumping)
        {
            yPos += verticalMovement * Time.deltaTime;
        }
        else
        {
            CharacterIsJumping = false;
        }
    }
}