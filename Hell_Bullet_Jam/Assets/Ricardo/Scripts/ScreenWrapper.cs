using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenWrapper : MonoBehaviour
{
    private Camera mainCamera;
    private Vector2 screenBounds;
    private TrailRenderer trail;

    void Start()
    {
        trail = gameObject.GetComponent<TrailRenderer>();
        mainCamera = Camera.main;
        screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
    }

    void Update()
    {
        Vector3 viewPos = transform.position;
        bool isWithinBounds = true;

        if (viewPos.x > screenBounds.x)
        {
            viewPos.x = -screenBounds.x;
            isWithinBounds = false;
        }
        else if (viewPos.x < -screenBounds.x)
        {
            viewPos.x = screenBounds.x;
            isWithinBounds = false;
        }

        if (viewPos.y > screenBounds.y)
        {
            viewPos.y = -screenBounds.y;
            isWithinBounds = false;
        }
        else if (viewPos.y < -screenBounds.y)
        {
            viewPos.y = screenBounds.y;
            isWithinBounds = false;
        }

        transform.position = viewPos;

        if (isWithinBounds)
        {
            trail.emitting = true;
        }
        else
        {
            trail.emitting = false;
        }
    }
}
