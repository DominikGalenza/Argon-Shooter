using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;
    [SerializeField] float xRange = 5f;
    [SerializeField] float yRange = 5f;
    void Update()
    {
        float xThrow = Input.GetAxis("Horizontal");
        float yThrow = Input.GetAxis("Vertical");

        float xOffset = xThrow * Time.deltaTime * moveSpeed;
        float newXPosition = transform.localPosition.x + xOffset;
        float clampedXPosition = Mathf.Clamp(newXPosition, -xRange, xRange);

        float yOffset = yThrow * Time.deltaTime * moveSpeed;
        float newYPosition = transform.localPosition.y + yOffset;
        float clampedYPosition = Mathf.Clamp(newYPosition, -yRange, yRange);

        transform.localPosition = new Vector3(clampedXPosition, clampedYPosition, transform.localPosition.z);
    }
}
