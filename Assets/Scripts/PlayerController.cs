using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    public float zRange = 8.5f;

    public ParticleSystem extraLifeParticle;
    public ParticleSystem bonusPointParticle;
    public ParticleSystem loseALifeParticle;
    public ParticleSystem loseAPointParticle;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("ExtraLife"))
        {
            extraLifeParticle.Play();
        }

        if (other.gameObject.CompareTag("BonusPoint"))
        {
            bonusPointParticle.Play();
        }

        if (other.gameObject.CompareTag("LoseALife"))
        {
            loseALifeParticle.Play();
        }

        if (other.gameObject.CompareTag("LoseAPoint"))
        {
            loseAPointParticle.Play();
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
