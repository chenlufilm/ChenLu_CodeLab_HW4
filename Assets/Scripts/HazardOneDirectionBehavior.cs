using UnityEngine;

public class HazardOneDirectionBehavior : MonoBehaviour
{
    //define hazard's targeting position and startposition (for respawning)
    public Transform targetPosition;
    public float speed;
    private Vector3 startPosition;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //set startpostition to hazard's initial world position
        startPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position,targetPosition.position,speed * Time.deltaTime);
        //hazard go back to initial position once reach the target position
        if (transform.position == targetPosition.position)
        {
            transform.position = startPosition;
        }
    }
}
