using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float dashSpeed = 10f;
    public float dashDuration = 1f;
    private float dashTimer = 0f;
    private bool isDashing = false;
    public GameObject playerTrail;

    void Update()
    {
        // Movimiento del jugador
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 movement = new Vector2(horizontalInput, verticalInput).normalized;
        transform.Translate(movement * moveSpeed * Time.deltaTime);

        // Actualizar la posición de la estela
        UpdateTrailPosition(transform.position);

        // Detección de dash
        if (Input.GetKeyDown(KeyCode.Space) && !isDashing && (horizontalInput != 0 || verticalInput != 0))
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
                dashTimer = 0f;
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
        float startTime = Time.time;

        while (Time.time < startTime + dashDuration)
        {
            yield return null;
        }
        isDashing = false;
    }
    void UpdateTrailPosition(Vector3 position)
    {
        // Actualizar la posición de la estela
        if (playerTrail != null)
        {
            playerTrail.transform.position = position;
        }
    }
}
