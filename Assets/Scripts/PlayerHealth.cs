using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    private float health;
    private float lerpTimer;

    [Header("Health Bar")]
    public float maxHealth = 100;
    public float chipSpeed = 2.0f;
    public float enemyDamage = 10.0f;
    public float bossDamage = 20.0f;
    public Image frontHealthBar;
    public Image backHealthBar;

    [Header("Overlay")]
    public Image overlay;
    public float duration;
    public float fadeSpeed;

    private float durationTimer;

    void Start()
    {
        health = maxHealth;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0);
    }

    void Update()
    {
        health = Mathf.Clamp(health, 0, maxHealth);
        UpdateHealthUI();

        if (health <= 0)
        {
            FindObjectOfType<GameManager>().EndGame();
        }

        if (overlay.color.a > 0)
        {
            if (health < 30)
                return;
            durationTimer += Time.deltaTime;
            if(durationTimer > duration)
            {
                float tempAlpha = overlay.color.a;
                tempAlpha -= Time.deltaTime * fadeSpeed;
                overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, tempAlpha);
            }
        }
    }

    public void UpdateHealthUI()
    {
        float fillFront = frontHealthBar.fillAmount;
        float fillBack = backHealthBar.fillAmount;
        float healthFraction = health / maxHealth; // menjaga nilai antara 0 - 1

        // menerima damage
        if (fillBack > healthFraction) 
        {
            frontHealthBar.fillAmount = healthFraction;
            backHealthBar.color = Color.red;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            // percentComplete = percentComplete * percentComplete;
            backHealthBar.fillAmount = Mathf.Lerp(fillBack, healthFraction, percentComplete);
        }

        // menerima heal
        if (fillFront < healthFraction)
        {
            backHealthBar.fillAmount = healthFraction;
            backHealthBar.color = Color.green;
            lerpTimer += Time.deltaTime;
            float percentComplete = lerpTimer / chipSpeed;
            // percentComplete = percentComplete * percentComplete;
            frontHealthBar.fillAmount = Mathf.Lerp(fillFront, healthFraction, percentComplete);
        }
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        lerpTimer = 0f;
        durationTimer = 0;
        overlay.color = new Color(overlay.color.r, overlay.color.g, overlay.color.b, 0.2f);
    }

    public void RestoreHelath(float healAmount)
    {
        health += healAmount;
        lerpTimer = 0f;
        durationTimer = 0;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject collisionObject = collision.gameObject;
        if (collisionObject.CompareTag("Enemy"))
        {
            TakeDamage(enemyDamage);
        } 
        else if(collisionObject.CompareTag("Enemy"))
        {
            TakeDamage(bossDamage);
        }
    }
}
