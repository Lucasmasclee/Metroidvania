using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;
using System.Collections;
using Unity.Burst.CompilerServices;

public class PlayerController : MonoBehaviour
{
    private Vector2 inputMovement;
    private Rigidbody2D myRigidBody;
    private Vector2 velocity;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float jumpSpeed = 5f;

    [SerializeField] private LayerMask layerPlayer;
    [SerializeField] private LayerMask layerEnemy;

    private bool isDodging = false;

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
        if (Input.GetKeyDown(KeyCode.Space) && !isDodging)
        {
            Dodge();
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

    private void Dodge()
    {
        DamageHealthSystem.instance.isInvincible = true;
        moveSpeed *= 1.5f;
        Physics.IgnoreLayerCollision(layerPlayer.value, layerEnemy.value, false);
        StartCoroutine(EndDodge(2f));

    }

    private IEnumerator EndDodge(float sec)
    {
        yield return new WaitForSeconds(sec);
        DamageHealthSystem.instance.isInvincible = false;
        moveSpeed *= 2f/3f;
        Physics.IgnoreLayerCollision(layerPlayer, layerEnemy, true);
    }
}
