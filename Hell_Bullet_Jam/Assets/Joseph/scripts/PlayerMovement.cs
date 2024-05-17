using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    public float dashCooldown = 3f; // Tiempo de espera entre dashes
    private float dashTimer = 0f;
    private bool isDashing = false;
    private bool canDash = true;
    private PlayerHealth playerHealth;

    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();
    }

    void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Detección de dash
        if (Input.GetKeyDown(KeyCode.Space) && canDash && !isDashing && (horizontalInput != 0 || verticalInput != 0))
        {
            StartCoroutine(Dash());
        }

        // Contador de tiempo del dash
        if (isDashing)
        {
            dashTimer += Time.deltaTime;
            if (dashTimer >= dashDuration)
            {
                isDashing = false;
                playerHealth.SetInvincible(false);
                dashTimer = 0f;
                StartCoroutine(DashCooldown());
            }
            else
            {
                // Permitir cambiar de dirección durante el dash
                float newHorizontalInput = Input.GetAxisRaw("Horizontal");
                float newVerticalInput = Input.GetAxisRaw("Vertical");
                Vector2 dashDirection = new Vector2(newHorizontalInput, newVerticalInput).normalized;
                transform.Translate(dashDirection * dashSpeed * Time.deltaTime);
            }
        }
    }

    IEnumerator Dash()
    {
        isDashing = true;
        playerHealth.SetInvincible(true);
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            yield return null;
        }
        isDashing = false;
        playerHealth.SetInvincible(false);
    }

    IEnumerator DashCooldown()
    {
        canDash = false;
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
    }
}
