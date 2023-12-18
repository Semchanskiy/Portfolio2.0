using System.Collections;
using System.Collections.Generic;
using System.Transactions;
using UnityEngine;
using UnityEngine.UIElements;

public class Enemy : MonoBehaviour
{

    public GameObject chosenEffect;
    private bool _isActive = true;

    public float _speed;
    public float maxSpeed;
    private Idol Idol;
    private Rigidbody rb;
    private LevelData LD;
    private AudioSource audioSource;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        LD = FindObjectOfType<LevelData>();
        rb = GetComponent<Rigidbody>();
        Idol = FindObjectOfType<Idol>();
        rb.AddForce(new Vector3(Random.Range(-50, 50), 0, Random.Range(-50, 50)));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector3 naprav = new Vector3(Idol.transform.position.x - transform.position.x, Idol.gameObject.transform.position.y - transform.position.y, Idol.gameObject.transform.position.z - transform.position.z);
        var distance = naprav.magnitude;
        var direction = naprav/distance;
        rb.AddForce(direction*_speed);
        CorrectMaxSpeed();
    }

    IEnumerator Effect(Collision collision)
    {
        ContactPoint contact = collision.contacts[0];
        Vector3 pos = contact.point;
        GameObject effectPlayer = (GameObject)Instantiate(chosenEffect, pos, transform.rotation);
        yield return new WaitForSeconds(2);
        Destroy(effectPlayer);
    }

    IEnumerator Wait (float time, float speed)
    {
        yield return new WaitForSeconds(time);
        if (_isActive)
        {
            _speed = speed;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        
        

        if (collision.collider.tag != "Ground")
        {
            StartCoroutine(Effect(collision));
            audioSource.pitch = Random.Range(0.9f, 1.1f);
            audioSource.Play();

        }
        if(collision.gameObject.tag == "Player")
        {
            _speed = 0;
            maxSpeed = 1000;
            _isActive = false;
        }

        //if (collision.collider.tag == "Idol")
        //{
        //    float startspeed = _speed;
        //    _speed = 0;
        //    StartCoroutine(Wait(2f, startspeed));
        //    
        //}
    }

    private void OnTriggerExit(Collider other)
    {
        if(other.gameObject.tag == "DeathEnemyZone")
        {
            LD.EnemyDestroyed();
            Destroy(gameObject);
        }
    }

    private void CorrectMaxSpeed()
    {
        Vector3 CurrentSpeed = rb.velocity;
        if (rb.velocity.x > maxSpeed)
        {
            CurrentSpeed.x = maxSpeed;
        }
        else if (rb.velocity.x < -maxSpeed)
        {
            CurrentSpeed.x = -maxSpeed;
        }

        if (rb.velocity.z > maxSpeed)
        {
            CurrentSpeed.z = maxSpeed;
        }
        else if (rb.velocity.z < -maxSpeed)
        {
            CurrentSpeed.z = -maxSpeed;
        }

        rb.velocity = CurrentSpeed;
    }
}
