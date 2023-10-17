using UnityEngine;

public class HealthBoosterScript : MonoBehaviour
{
    public int healthBoost = 10;  // Amount of health to be restored
    public float respawnTime = 10f;
    private float respawnTimer = 10f;
    public GameObject orb;


    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Heal player, make orb disappear, set respawn timer for orb
            other.GetComponent<PlayerHealth>().playerHealth += 10;
            orb.SetActive(false);
            gameObject.GetComponent<SphereCollider>().enabled = false;
            respawnTimer = 0f;
        }
    }


    private void Update()
    {
        // If respawn timer is still lesss than 10 seconds, increment by time since last frame
        if (respawnTimer < 10f)
        {
            respawnTimer += Time.deltaTime;
        }
        // Once 10 seconds has passed, respawn orb
        else if (respawnTimer >= respawnTime && orb.activeSelf == false)
        {
            orb.SetActive(true);
            gameObject.GetComponent<SphereCollider>().enabled = true;
        }
    }
}
