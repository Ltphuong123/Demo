using System.Collections;
using System.Collections.Generic;
using System.Resources;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Scripting.APIUpdating;

public class player : MonoBehaviour
{
    Vector2 rawInput;
    [SerializeField] float moveSpeed = 5f;
    Vector3 targetPosition;


    void Update()
    {
        Move();
    }


    void Move()
    {
        targetPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        targetPosition.z = 0f;
        transform.position = Vector3.Lerp(transform.position, targetPosition, moveSpeed * Time.deltaTime);
    }

}
