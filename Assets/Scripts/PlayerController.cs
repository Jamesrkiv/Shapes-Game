using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody playerRb;
    public float speed = 5;
    private GameObject focalPoint;
    private HealthPoints healthPoints;
    
    public bool hasGem = false; // Details for gem powerup
    private bool gemEffect = false;
    private float gemStrength = 15;
    private float gemTime = 10;

    public float dashCooldown = 2; // Time between dashes
    private bool canDash = true;
    public float dashSpeed;
    public GameObject dashEnabled;  //dash icon for active dash
    public GameObject dashDisabled; //dash icon for inactive dash

    public GameObject powerupIndicator;
    public Vector3 powerUpOffset;

    public GameObject enemyThump;
    public GameObject moneyGet;
    public GameObject bounceSurface;
    public GameObject hpGet;

     

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody>();
        focalPoint = GameObject.Find("Focal Point");
        powerUpOffset = powerupIndicator.transform.position;
        healthPoints = GetComponent<HealthPoints>();
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.y < -10)
        {
            Destroy(gameObject);
            Debug.Log("Game over!");
        }

        if (Input.GetKeyDown("space") && canDash)
        {
            canDash = false;
            playerRb.AddForce(focalPoint.transform.forward * dashSpeed);
            dashEnabled.SetActive(false);
            dashDisabled.SetActive(true);
            StartCoroutine(DashCooldown());
        }

        if (hasGem) // hasGem set to true by Shop.cs, detected here
        {
            hasGem = false; // Immediately set to false to avoid infinite calls
            gemEffect = true;
            healthPoints.haveGem = true; // Signals HP script to enable damage multiplier
            StartCoroutine(PowerupCountdownRoutine());
            powerupIndicator.gameObject.SetActive(true);

            Debug.Log("Powerup get");
        }
    }

    // Runs in fixed time steps (independent of fps)
    private void FixedUpdate()
    {
        float forwardInput = Input.GetAxis("Vertical");
        playerRb.AddForce(focalPoint.transform.forward * forwardInput * speed);
        powerupIndicator.transform.position = transform.position + powerUpOffset;
    }

    private void OnTriggerEnter(Collider other)
    {
        switch (other.tag)
        {
            /*
            case "Powerup":
                if (!hasGem)
                {
                    Destroy(other.gameObject);
                    hasGem = true;
                    StartCoroutine(PowerupCountdownRoutine());
                    powerupIndicator.gameObject.SetActive(true);

                    Debug.Log("Powerup get");
                }
                break;
              */

            case "Cash":
                moneyGet.GetComponent<AudioSource>().Play();
                break;

            case "HealthPack":
                hpGet.GetComponent<AudioSource>().Play();
                break;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Enemy": // Collide with enemy
                if (gemEffect)
                {
                    Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
                    Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
                    enemyRb.AddForce(awayFromPlayer * gemStrength, ForceMode.Impulse);
                }
                enemyThump.GetComponent<AudioSource>().Play();
                break;
           
            case "Obst": // Collide with obstacle
                bounceSurface.GetComponent<AudioSource>().Play();
                break;
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(gemTime);
        gemEffect = false;
        healthPoints.haveGem = false;
        powerupIndicator.gameObject.SetActive(false);

        Debug.Log("Powerup timer end");
    }

    IEnumerator DashCooldown()
    {
        yield return new WaitForSeconds(dashCooldown);
        canDash = true;
        dashEnabled.SetActive(true);
        dashDisabled.SetActive(false);
        Debug.Log("Dash ready");
    }
}
