using UnityEngine;

public class HazardBnFBehavior : MonoBehaviour
{
    //define back and forth hazard's pointA and pointB positions for BnF movement 
    public Transform pointA;
    public Transform pointB;
    public float speed;
    private Vector3 targetPosition;
    

    //define BnF hazard's movement state: true-moving to pointB; False-moving to pointA
    private bool movingToB = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set start position to hazard's initial world position
        transform.position = pointA.position;
        targetPosition = pointB.position;
    }

    // Update is called once per frame
    void Update()
    {
        //moving to pointB is set to true at first, hazard move from a to b until hazard reaches pointB, set movingToB back to false
        //then set targetposition to pointA and let hazard move towards new targetposition (pointA). 
        //once hazard reaches new targetposition(pointA), set moving to B back to true and it will loop back to set targetposition to pointB
        if (movingToB == true)
        {
            targetPosition = pointB.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                movingToB = false;
            }
        }
        else if (movingToB == false)
        {
            targetPosition = pointA.position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                movingToB = true;
            }
        }
    }
}

    
