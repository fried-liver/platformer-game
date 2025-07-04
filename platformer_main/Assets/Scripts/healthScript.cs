using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class healthScript : MonoBehaviour
{
    public int health;
    public TMP_Text healthText;
    public float attackCooldown;
    public GameObject spawn;

    private float lastAttack;
    private int maxHealth;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        maxHealth = health;
    }

    // Update is called once per frame
    void Update()
    {
        
        healthText.text = health.ToString();
        if (health <= 0)
        {
            die();
        }
    }
    public void die()
    {
        
        health = maxHealth;
        transform.position = spawn.transform.position;
        
    }
    public void dealDamage(int damage, float time)
    {
        
        if (lastAttack > time)
        {
            health -= damage;
            Debug.Log(health);
            //Do Stuff
            lastAttack = 0f;

        }
        lastAttack += Time.deltaTime;
        
    }
}
