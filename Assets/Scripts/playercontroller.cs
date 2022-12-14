using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playercontroller : MonoBehaviour
{
    Rigidbody playerrb;
    public GameObject PowerUpIndicator;
    GameObject focalpoint;
    public float speed = 5f;
    public float powerstrength=15f;
   public bool haspowerup;
    // Start is called before the first frame update
    void Start()
    {
        haspowerup = false;
        playerrb = GetComponent<Rigidbody>();
        focalpoint = GameObject.Find("Focal point");
    }

    // Update is called once per frame
    void Update()
    {
        float vertical = Input.GetAxis("Vertical");

        playerrb.AddForce(focalpoint.transform.forward * vertical * speed );
        PowerUpIndicator.transform.position = transform.position + new Vector3(0, -0.3f, 0);



    }
    IEnumerator PowerUpRoutine()
    {
        yield return new WaitForSeconds(7);
        haspowerup = false;
        PowerUpIndicator.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.CompareTag("PowerUp"))
        {
            haspowerup = true;
            Destroy(other.gameObject);
            if (haspowerup) 
            {
                PowerUpIndicator.SetActive(true);
                StartCoroutine(PowerUpRoutine());
            }
           
            
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy")&&haspowerup)
        {
            Rigidbody enemyRb = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 away = enemyRb.position - transform.position;
            enemyRb.AddForce(away * powerstrength, ForceMode.Impulse);
            Debug.Log("we are collied with " + collision.gameObject.name + " haspowerup set to " + haspowerup);
        }
       
    }
}
