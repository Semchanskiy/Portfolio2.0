using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallSound : MonoBehaviour
{
    private AudioSource _stepSound;
    private bool _isTimeSound;

    // Start is called before the first frame update
    void Start()
    {
        _stepSound = GetComponent<AudioSource>();
        _isTimeSound = true;
    }

    void Update()
    {
        bool soundtouch = Physics2D.OverlapCircle(transform.position, .5f, LayerMask.GetMask("Ground"));
        if (soundtouch)
        {

        }
        else
        {
            _isTimeSound = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameCore.BAT.gameObject)
        {
            
        }
        else
        {
            if (_isTimeSound)
            {
                if(collision.gameObject.tag != "Glove")
                {
                _stepSound.Play();
                _isTimeSound = false;

                }
            }

        }
    }
}
