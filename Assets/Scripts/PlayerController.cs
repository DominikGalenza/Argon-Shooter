using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 40f;
    [SerializeField] float xRange = 15f;
    [SerializeField] float yRange = 15f;
    [SerializeField] float positionYPitchFactor = -3f;
    [SerializeField] float controlYPitchFactor = 15f;
    [SerializeField] float positionYawFactor = 2f;
    [SerializeField] float controlRollFactor = -10f;
    [SerializeField] GameObject[] lasers;

    float xThrow, yThrow;

    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
        ProcessFire();
    }

    void ProcessRotation()
    {
        float pitchDueToYPosition = transform.localPosition.y * positionYPitchFactor;
        float pitchDueToYControlThrow = yThrow * controlYPitchFactor;
        float pitchDueToXPosition = transform.localPosition.x * positionYawFactor;
        float pitchDueToXControlThrow = xThrow * controlRollFactor;

        float pitch = pitchDueToYPosition + pitchDueToYControlThrow;
        float yaw = pitchDueToXPosition;
        float roll = pitchDueToXControlThrow;
        transform.localRotation = Quaternion.Euler(pitch, yaw, roll);
    }

    void ProcessTranslation()
    {
        xThrow = Input.GetAxis("Horizontal");
        yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float newXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(newXPosition, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * moveSpeed;
        float newYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(newYPosition, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, transform.localPosition.z);
    }

    void ProcessFire()
    {
        if(Input.GetButton("Fire1"))
        {
            ActivateLasers();
        }
        else
        {
            DeactivateLasers();
        }
    }

    void ActivateLasers()
    {
        foreach(GameObject laser in lasers)
        {
            laser.SetActive(true);
        }
    }

    void DeactivateLasers()
    {
        foreach(GameObject laser in lasers)
        {
            laser.SetActive(false);
        }
    }
}
