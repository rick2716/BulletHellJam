using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 4;
    private int currentHealth;
    public Slider healthSlider;
    private bool isInvincible = false;

    void Start()
    {
        currentHealth = maxHealth;
        healthSlider.maxValue = maxHealth;
        healthSlider.value = currentHealth;
    }

    public void TakeDamage(int damage)
    {
        if (isInvincible)
        {

            return; // No hacer daño si es invencible
        }

        currentHealth -= damage;
        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        healthSlider.value = currentHealth;

        if (currentHealth <= 0)
        {
            // Manejar la muerte del jugador aquí
            Debug.Log("Player is dead!");
        }
    }

    public void Heal(int amount)
    {
        currentHealth += amount;
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthSlider.value = currentHealth;
    }

    public void SetInvincible(bool state)
    {
        isInvincible = state;
    }
}
