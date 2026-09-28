using UnityEngine;

public class PowerUpBehaviourScript : MonoBehaviour
{
    //set powerUp's starting postition
    private Vector3 startPositon;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startPositon = transform.position;
    }

    //reset powerUp once Player gets powerUp
    public void resetPowerUp()
    {
        transform.position = startPositon;
        gameObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
