using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DamageHealthSystem : MonoBehaviour
{
    public static DamageHealthSystem instance;
    [SerializeField] private Transform healthbar;
    [SerializeField] private float startHealth;
    [SerializeField] private float health;
    private float healthbarSize;

    [SerializeField] private GameObject healthbarBG;

    private void Start()
    {
        instance = this;
        healthbarSize = healthbar.localScale.x;
        health = startHealth;
    }
    void Update()
    {
        if (health <= 0)
        {
            GameManager.instance.GameOver();
        }
        healthbar.localScale = new Vector3(health/startHealth * healthbarSize, healthbar.localScale.y, healthbar.localScale.z);
        healthbar.localPosition = new Vector3((healthbar.localScale.x/2) - healthbarBG.transform.localScale.x/2, healthbar.localPosition.y, healthbar.localPosition.z);
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        
    }
}
