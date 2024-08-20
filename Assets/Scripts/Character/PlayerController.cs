using DG.Tweening;
using UnityEngine;
using UnityEngine.Rendering.Universal;
using System;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    private enum StickySide
    {
        LEFT = -1,
        RIGHT = 1
    }
    private Vector2 inputMovement;
    private Rigidbody2D myRigidBody;
    private Vector2 velocity;
    private CapsuleCollider2D myFeetCollider;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float jumpSpeed = 5f;
    private float realStickyCooldown;
    private bool canSticky;
    private Light2D light2D;
    private Status status;
    private Vector2 lastCheckpointPosition;
    private int lastCheckpointIndex;

    private void Awake()
    {
        myRigidBody = GetComponent<Rigidbody2D>();
        myFeetCollider = GetComponent<CapsuleCollider2D>();
        light2D = GetComponentInChildren<Light2D>();
    }

    private void LateUpdate()
    {
        if (gameObject != null)
        {
            ChangeXVelocity(0);
        }
    }

    public void SetStatus(int index)
    {
        if (status == null)
        {
            this.status = new Status(index);
        }
    }

    public bool Move()
    {
        if (this == null)
        {
            return false;
        }
        if (!canSticky)
        {
            realStickyCooldown -= Time.fixedDeltaTime;
            canSticky = realStickyCooldown <= 0;
        }
        ChangeXVelocity(inputMovement.x * (moveSpeed * Time.fixedDeltaTime));
        return true;
    }

    private void ChangeXVelocity(float x)
    {
        velocity = myRigidBody.velocity;
        velocity.x = x;
        myRigidBody.velocity = velocity;
    }

    public void OnMovement(Vector2 value)
    {
        //Debug.Log(value);
        inputMovement = value;
        if (light2D != null)
        {
            light2D.enabled = true;

        }
    }

    public Vector2 ShrinkToNewScale(float shrinkSpeed)
    {
        Vector2 newLocalScale = NewSplittedScale(this.transform.localScale);
        this.transform.DOScale(newLocalScale, shrinkSpeed);
        return newLocalScale;
    }

    private Vector2 NewSplittedScale(Vector2 startScale)
    {
        float newX = Mathf.Sqrt(startScale.x * startScale.x / 2);
        float newY = Mathf.Sqrt(startScale.y * startScale.y / 2);
        return new Vector2(newX, newY);
    }

    private Vector2 GrowToNewScale(float shrinkSpeed)
    {
        Vector2 newLocalScale = new Vector2(Mathf.Sqrt(Mathf.Pow(this.transform.localScale.x,2) * 2), Mathf.Sqrt(Mathf.Pow(this.transform.localScale.y,2) * 2));
        this.transform.DOScale(newLocalScale, shrinkSpeed) ; 
        return newLocalScale;
    }

    public void OnJump()
    {
        if (IsOnGround())
        {
            myRigidBody.velocity += (Vector2.up * jumpSpeed);
        }
    }
    public void StopMovement()
    {
        myRigidBody.velocity = Vector2.zero;
        inputMovement = Vector2.zero;
        light2D.enabled = false;
    }

    private bool IsFeetTouching(params string[] layers) => myFeetCollider.IsTouchingLayers(LayerMask.GetMask(layers));

    private bool IsOnGround() =>
        IsFeetTouching(Constants.FLOOR_LAYER,
            Constants.PLAYER_LAYER,
            Constants.CHAR_Blue_LAYER,
            Constants.CHAR_Pink_LAYER,
            Constants.CHAR_Green_LAYER,
            Constants.FLOOR_Blue_LAYER,
            Constants.FLOOR_Pink_LAYER,
            Constants.FLOOR_Green_LAYER,
            Constants.Firing_Tower_LAYER,
            Constants.Firing_tower_LAYER,
            Constants.Trampo_LAYER,
            Constants.Ice_LAYER);
}
