using UnityEditor.Build.Player;
using UnityEngine;

public class HazardTrackingBehavior : MonoBehaviour
{
    //set tracker's target's position, in this case the player we can drag onto this hazard later
    public Transform player;
    //expose tracking hazard's tracking speed, also expose parameters of within how much range within the tracker would 
    //players be tracked, and how far the player need to be away from the tracker in order to escape
    
    public float speed;
    public float trackingDistance;
    public float escapeDistance;
    //set the tracking hazard's tracking state
    private bool tracking = false;

    //define new function for tracker to respawn randomly within game's screen
    public void respawnRandom()
    {
        float randomX = Random.Range(-6.45f, 10.12f);
        float randomY = Random.Range(-2.61f, 3.18f);
        transform.position = new Vector3(randomX, randomY, 0);
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        //update tracker's distance to player every frame
        float distanceToPlayer = Vector3.Distance(transform.position,player.position);
        //if tracker is in tracking distance in relationship to player, start tracking
        if (tracking == false && distanceToPlayer <= trackingDistance)
        {
            tracking = true;
        }
        //tracking player is to move tracker's position towards current player's position with customized tracker speed
        if (tracking == true)
        {
            transform.position = Vector3.MoveTowards(transform.position, player.position, speed * Time.deltaTime);
        }
        //if player manages to exceed tracker's range (distance more than escapeDistance), tracker stop tracking state, and respawn to new random position
        if (tracking == true && distanceToPlayer >= escapeDistance)
        {
            respawnRandom();
            tracking = false;
        }
    }
}
