using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using static UnityEngine.RuleTile.TilingRuleOutput;

public class Bat : MonoBehaviour, IMoveble, IDamageble
{
    private PlayerLogic Player;
    private Rigidbody2D _rb;
    [SerializeField] private float _speed;

    void Start() 
    {
        Player = FindObjectOfType<PlayerLogic>();
        _rb = GetComponent<Rigidbody2D>();
    }
    public void Move()
    {
        Vector2 heading = Player.transform.position - transform.position; //��������������� ������ ����������
        float distance = heading.magnitude; //��������� ����� �������
        Vector2 direction = heading / distance; // ������������� ������, �����������
        _rb.velocity = direction * _speed;
    }

    void Update () 
    {
        Move();
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Player.Death();
        }
    }
}
