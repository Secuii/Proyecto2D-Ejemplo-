using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float playerMaxSpeed = 4f;
    [SerializeField] private float playerAccelerationTime = 0.4f;
    [SerializeField] private float playerCurrentSpeed = 0;

    void Start()
    {
        playerCurrentSpeed = playerMaxSpeed / playerAccelerationTime;
    }

    void Update()
    {

        if (Input.GetKey(KeyCode.A))
        {
            playerCurrentSpeed += Time.deltaTime;
        }


    }
}
