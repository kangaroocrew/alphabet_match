using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    // Position / motion state
    Vector3 StartPosition;
    Quaternion StartRotation;
    bool AnimateFlag;

    float gravity;
    float x_position;
    float y_position;
    float x_velocity;
    float y_velocity;

    // Rotation state
    float rotationSpeed;   // degrees per second

    // How far past the bottom of the screen the star must go
    // before we consider it "gone" (in screen pixels).
    [SerializeField] float screenBottomPadding = 50f;

    void Start()
    {
        AnimateFlag = false;

        // Where this star lives in the layout
        StartPosition = transform.localPosition;
        StartRotation = transform.localRotation;

        gameObject.SetActive(false);
    }

    public void Reset()
    {
        AnimateFlag = false;

        // Reset motion
        x_position = StartPosition.x;
        y_position = StartPosition.y;
        x_velocity = 0f;
        y_velocity = 0f;

        // Reset transform
        transform.localPosition = StartPosition;
        transform.localRotation = StartRotation;

        gameObject.SetActive(false);
    }

    public void Animate()
    {
        // Start from the original grid position
        x_position = StartPosition.x;
        y_position = StartPosition.y;

        // --- TUNING: slightly slower + softer gravity than original ---
        // You can tweak these numbers if you want more or less "float".
        x_velocity = UnityEngine.Random.Range(150f, 350f);   // was 30–80
        y_velocity = UnityEngine.Random.Range(250f, 450f); // was 340–360
        gravity = -3f;                                  // was -12f

        // Random left / right
        if (UnityEngine.Random.Range(0f, 100f) > 50f)
        {
            x_velocity *= -1f;
        }

        // --- Rotation flair ---
        // Random spin speed and direction, in degrees/second
        float baseSpin = UnityEngine.Random.Range(180f, 540f); // 0.5–1 full spin per second
        float direction = UnityEngine.Random.value > 0.5f ? 1f : -1f;
        rotationSpeed = baseSpin * direction;

        // Ensure we start from the "correct" resting rotation
        transform.localRotation = StartRotation;

        AnimateFlag = true;
        gameObject.SetActive(true);
    }

    void Update()
    {
        if (!AnimateFlag)
            return;

        // Same basic motion pattern as original, just with tweaked numbers
        x_position += Time.deltaTime * x_velocity;
        y_position += Time.deltaTime * y_velocity;
        y_velocity += gravity;

        transform.localPosition = new Vector3(
            x_position,
            y_position,
            StartPosition.z
        );

        // Apply the spin (around Z axis for UI)
        transform.Rotate(0f, 0f, rotationSpeed * Time.deltaTime, Space.Self);

        // Convert to screen space and check against actual bottom of screen
        Vector3 screenPos = RectTransformUtility.WorldToScreenPoint(null, transform.position);

        if (screenPos.y < -screenBottomPadding)
        {
            Reset();
        }
    }
}
