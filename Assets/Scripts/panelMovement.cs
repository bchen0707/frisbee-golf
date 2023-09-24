using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class panelMovement : MonoBehaviour
{
    [SerializeField] float _moveDistance = 3f;
    [SerializeField] float _moveSpeed = 1f;

    private float journeyLength;
    private float startTime;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private bool movingUp = false;

    private void Start()
    {
        startPosition = transform.localPosition;
        endPosition = new Vector3(startPosition.x, startPosition.y - _moveDistance, startPosition.z);
        journeyLength = Vector3.Distance(startPosition, endPosition);
        // Keep a note of the time the movement started.
        startTime = Time.time;
    }

    private void Update()
    {
        // Calculate the journey length and start time once in Start method.
        float distCovered = (Time.time - startTime) * _moveSpeed;

        // Fraction of journey completed equals current distance divided by total distance.
        float fractionOfJourney = distCovered / journeyLength;

        if (movingUp)
        {
            // Move up
            transform.localPosition = Vector3.Lerp(endPosition, startPosition, fractionOfJourney);
        }
        else
        {
            // Move down
            transform.localPosition = Vector3.Lerp(startPosition, endPosition, fractionOfJourney);
        }

        // Check if we reached the end position
        if (fractionOfJourney >= 1.0f)
        {
            movingUp = !movingUp; // Switch direction
            startTime = Time.time; // Reset the start time for smooth movement
        }
    }
}

