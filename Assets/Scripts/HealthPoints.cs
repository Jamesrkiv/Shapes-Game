using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPoints : MonoBehaviour
{
    // This script is intended for use by the player AND enemies

    public int hp;
    public int maxHP;
    public int healthPackAmount = 50;

    private int damage; // Damage to be dealt
    public int playerDamageMultiplier;

    private float Speed; // Current speed
    public float UpdateDelay; // Delay between updating current speed (in seconds)

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpeedReckoner());
    }

    // Update is called once per frame
    void Update()
    {
        if (hp <= 0) // Destroys entity if HP hits zero
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy") && !gameObject.CompareTag("Enemy")) // Prevents enemies from hurting one another
        {
            damage = (int) Speed * playerDamageMultiplier; // Drops decimal
            HealthPoints targetHP = collision.gameObject.GetComponent<HealthPoints>();

            targetHP.hp -= damage; // Damage being applied

            Debug.Log(damage + " damage dealt!");
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            damage = (int)Speed; // Drops decimal
            HealthPoints targetHP = collision.gameObject.GetComponent<HealthPoints>();

            targetHP.hp -= damage; // Damage being applied

            Debug.Log(damage + " damage taken!");
        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthPack") && !gameObject.CompareTag("Enemy")) //Prevents enemies from picking up healthpack
        {
            if (hp >= maxHP)
            { 
                Debug.Log("HP is Full");
            }
            else if (hp < maxHP)
            {
                hp += healthPackAmount;
                if (hp > maxHP)
                {
                    hp = maxHP;
                    Destroy(other.gameObject);
                }
                else
                {
                    Destroy(other.gameObject);
                }
            }
        }
    }

    // Used for calculating speed
    private IEnumerator SpeedReckoner()
    {

        YieldInstruction timedWait = new WaitForSeconds(UpdateDelay);
        Vector3 lastPosition = transform.position;
        float lastTimestamp = Time.time;

        while (enabled)
        {
            yield return timedWait;

            var deltaPosition = (transform.position - lastPosition).magnitude;
            var deltaTime = Time.time - lastTimestamp;

            if (Mathf.Approximately(deltaPosition, 0f)) // Clean up "near-zero" displacement
                deltaPosition = 0f;

            Speed = deltaPosition / deltaTime;

            lastPosition = transform.position;
            lastTimestamp = Time.time;

            // if (gameObject.CompareTag("Player")) Debug.Log(Speed); // Tracks player speed only
        }
    }
}
