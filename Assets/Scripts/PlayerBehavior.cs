using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Controls;
using UnityEngine.Rendering;

public class PlayerBehavior : MonoBehaviour
{
    //define Player inputs
    InputAction upButton;
    InputAction downButton;
    InputAction leftButton;
    InputAction rightButton;
    
    //define player's moving speed,normal speed and powerup speed
    private float speed;
    public float normalSpeed;
    public float powerUpSpeed;
    //Expose powerUp's behavior script to player script 
    public PowerUpBehaviourScript powerUp;
    //Expose tracking Hazards' behavior script to player script
    public HazardTrackingBehavior  hazardTracking;
    
    //define Player's starting position
    private Vector3 startPosition;
    
    //define new function: player respawns back to startpostion once hit hazards
    void resetPlayer()
    {
        transform.position = startPosition;
        powerUp.resetPowerUp();
    } 
    
    //define AudioSource for Hazards and Score Area
   public AudioSource hazardsPlayer;
   public AudioSource scorePlayer;
   public AudioSource powerUpPlayer;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //record startPosition at Player's original position
        startPosition = transform.position;
        
        //call preset input system
        upButton = InputSystem.actions.FindAction("Up");
        downButton = InputSystem.actions.FindAction("Down");
        leftButton = InputSystem.actions.FindAction("Left");
        rightButton = InputSystem.actions.FindAction("Right");
        
        //set player's speed to normal speed at first
        speed = normalSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        //Press WASD or Arrow Keys to move Player Character Up/Left/Down/Right
        Vector3 playerPosition = transform.position;
        if (upButton.IsPressed())
        {
            playerPosition.y += speed * Time.deltaTime;
            Debug.Log("Go up!");
        }

        if (downButton.IsPressed())
        {
            playerPosition.y -= speed * Time.deltaTime;
            Debug.Log("Go down!");
        }

        if (leftButton.IsPressed())
        {
            playerPosition.x -= speed * Time.deltaTime;
        }

        if (rightButton.IsPressed())
        {
            playerPosition.x += speed * Time.deltaTime;
        }
        //Player cannot leave camera's bounds 
        playerPosition.x = Mathf.Clamp(playerPosition.x, -8.22f, 8.28f);
        playerPosition.y = Mathf.Clamp(playerPosition.y, -3.39f, 5.38f);
        transform.position = playerPosition;
    }

    void OnTriggerEnter(Collider other)
    {
        //when collide with all kinds of hazards, play hazard sound effect and reset player's position, player's speed back to normalSpeed
        if (other.CompareTag("Hazards"))
        {
            hazardsPlayer.PlayOneShot(hazardsPlayer.clip);
            Debug.Log("Touched Hazards");
            speed = normalSpeed;
            resetPlayer();
        }

        //when collide with final score area's collider, play score sound effect and reset player's position, player's speed back to normalSpeed
        //tracking Hazard respawn to random position on game screen
        if (other.CompareTag("Score"))
        {
            scorePlayer.PlayOneShot(scorePlayer.clip);
            Debug.Log("Touched Ending Area");
            speed = normalSpeed;
            hazardTracking.respawnRandom();
            resetPlayer();
        }

        //when collided with powerUp, play power up sound effet, set speed to powerUp speed and then deactivate powerUp
        if (other.CompareTag("PowerUp"))
        {
            powerUpPlayer.PlayOneShot(powerUpPlayer.clip);
            speed = powerUpSpeed;
            other.gameObject.SetActive(false);
            Debug.Log("PowerUp");
        }
    }
}
