using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeSystem : MonoBehaviour
{
    public int maxHealth = 3;
    public int currentHealth;

    public PlayerHealth PlayerHealthBar;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        PlayerHealthBar.SetMaxHealth(maxHealth);
    }

    void Update()
    {
        if (currentHealth <= 0)
        {
            Destroy(gameObject);
            //add a change scene to our game over scene whenever added
        }
    }

    private void OnTriggerEnter(Collider collision)
    {
        //when player collides with target

        if (collision.transform.gameObject.CompareTag("Enemy"))
        {
            CooldownStart();
        }
    }
    void TakeDamage(int damage)
    {
        currentHealth -= damage;

        PlayerHealthBar.SetHealth(currentHealth);
    }

    void HealDamage(int damage)
    {
        currentHealth += damage;

        PlayerHealthBar.SetHealth(currentHealth);
    }
    public float healthCooldown;
    private bool cool = true;

    public void CooldownStart()
    {
        //i have no idea how this works
        StartCoroutine(CooldownCoroutine());
    }
    IEnumerator CooldownCoroutine()
    {
        cool = false;
        TakeDamage(1);
        yield return new WaitForSeconds(healthCooldown);
        cool = true;
    }
}
