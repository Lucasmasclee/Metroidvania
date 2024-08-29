using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private Vector2 inputMovement;
    private Rigidbody2D myRigidBody;
    private Vector2 velocity;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float jumpSpeed = 5f;

    private CameraBehaviors cameraBehaviors;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        cameraBehaviors = GetComponentInChildren<CameraBehaviors>();
    }

    private void Update()
    {
        if (gameObject != null)
        {
            inputMovement = GameManager.Instance.InputManager.Movement;
            Move();
        }
    }

    public bool Move()
    {
        if (this == null)
        {
            return false;
        }
        ChangeXVelocity(inputMovement.x * (moveSpeed * Time.fixedDeltaTime), inputMovement.y * (moveSpeed*Time.fixedDeltaTime));
        return true;
    }

    private void ChangeXVelocity(float x, float y)
    {
        velocity = myRigidBody.velocity;
        velocity.x = x;
        velocity.y = y;
        myRigidBody.velocity = velocity;
    }
}
