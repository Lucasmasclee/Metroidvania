using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Vector2 inputMovement;
    private Rigidbody2D myRigidBody;
    private Vector2 velocity;
    [SerializeField] private float moveSpeed = 100f;
    [SerializeField] private float jumpSpeed = 5f;
    [SerializeField] private float damage;
    [SerializeField] private Transform player;


    private bool dealingdamage = false;

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
        }
        Vector2 direction = new Vector2(player.transform.position.x - transform.position.x , player.transform.position.y - transform.position.y);
        direction.Normalize();
        ChangeXVelocity(direction.x * moveSpeed * Time.fixedDeltaTime, direction.y * moveSpeed * Time.fixedDeltaTime);
        
    }

    private void ChangeXVelocity(float x, float y)
    {
        velocity = myRigidBody.velocity;
        myRigidBody.velocity = new Vector2(x,y);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        dealingdamage = true;
        StartCoroutine(DamagePerTime(1f, damage));
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        dealingdamage = false;
        StopCoroutine(DamagePerTime(1f, damage));
    }

    private IEnumerator DamagePerTime(float sec, float damagex)
    {
        while (dealingdamage)
        {
            Debug.Log("Dealing Damage");
            DamageHealthSystem.instance.DealDamage(damage);
            yield return new WaitForSeconds(1f);
        }
    }
}
