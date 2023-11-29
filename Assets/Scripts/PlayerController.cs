using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float zRange = 8.5f;

    public ParticleSystem extraLifeParticle;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("ExtraLife"))
        {
            extraLifeParticle.Play();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExtraLife"))
        {
            extraLifeParticle.Play();
        }
    }

    void Update()
    {
        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange );
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y,zRange);
        }

        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector3.forward * horizontalInput * Time.deltaTime * speed);
    }
}
