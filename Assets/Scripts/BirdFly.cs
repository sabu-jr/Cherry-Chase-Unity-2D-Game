using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdFly : MonoBehaviour
{
    public float speed = 5f; // Speed at which the birds move
    public float[] path; // Array of points for the bird to move along
    private int currentPoint = 0; // Index of the current point in the path

    void Update()
    {
        // Move the bird towards the current point in the path
        //transform.position = Vector3.MoveTowards(transform.position, path[currentPoint], speed * Time.deltaTime);
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(path[currentPoint], transform.position.y, transform.position.z), speed * Time.deltaTime);

        // If the bird reaches the current point, move to the next point
        //if (transform.position == path[currentPoint])
        if (transform.position == new Vector3(path[currentPoint], transform.position.y, transform.position.z))
        {
            currentPoint++;

            // If the bird reaches the end of the path, start over
            if (currentPoint >= path.Length)
            {
                currentPoint = 0;
            }
        }
    }
}
