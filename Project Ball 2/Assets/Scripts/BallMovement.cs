using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using static UnityEngine.EventSystems.StandaloneInputModule;

public class BallMovement : MonoBehaviour
{

    private Rigidbody rb;
    private Vector2 napr = Vector2.zero;
    public float _speed;
    public float maxSpeed;
    private Transform _transform;

    private float x_left;
    private float x_right;
    private float z_top;
    private float z_bot;

    // Start is called before the first frame update
    void Start()
    {
        AddInvisibleWalls();

        _transform = GetComponent<Transform>();
        rb = GetComponent<Rigidbody>();
    }

    private void AddInvisibleWalls()
    {
        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        x_left = leftBot.x + 0.8f;
        x_right = rightTop.x - 0.8f;
        z_top = rightTop.z - 0.8f;
        z_bot = leftBot.z + 0.8f;


        // ограничиваем объект в плоскости XZ
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.z = Mathf.Clamp(clampedPos.z, z_bot, z_top);
        transform.position = clampedPos;
    }

    public void AddForce(Vector2 vector)
    {
        rb.AddForce(new Vector3(vector.x,0 ,vector.y)*_speed);
        CorrectTransform();
        CorrectMaxSpeed();
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
    private void CorrectTransform()
    {
        if (_transform.position.x >= x_right)
        {
            rb.velocity = new Vector3(0,rb.velocity.y,rb.velocity.z);
            rb.AddForce(new Vector3(2*-_speed,0,0));
        }
        if (_transform.position.x <= x_left)
        {
            rb.velocity = new Vector3(0, rb.velocity.y, rb.velocity.z);
            rb.AddForce(new Vector3(2 * _speed, 0, 0));
        }
        if (_transform.position.z >= z_top)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y,0);
            rb.AddForce(new Vector3(0, 0, 2 * -_speed));
        }
        if (_transform.position.z <= z_bot)
        {
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 0);
            rb.AddForce(new Vector3(0, 0, 2 * _speed));
        }
    }
}
