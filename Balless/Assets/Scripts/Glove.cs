using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Glove : MonoBehaviour
{
    private SpriteRenderer _sr;
    private Rigidbody2D _rb;
    private PolygonCollider2D _polygonCollider;
    private UIBalless _UI;
    
    [SerializeField] private Sprite _closeGlove;
    [SerializeField] private Sprite _openGlove;
    private Vector3 _startPointGlove;
    private ActiveScore activeScore;
    private MaxScore maxScore;


    
    void Start()
    {
        _startPointGlove = transform.position;
        _sr = GetComponent<SpriteRenderer>();
        _rb = GetComponent<Rigidbody2D>();
        _polygonCollider = GetComponent<PolygonCollider2D>();
        _UI = FindAnyObjectByType<UIBalless>();
        activeScore = FindAnyObjectByType<ActiveScore>();
        maxScore = FindAnyObjectByType<MaxScore>();
        
    }

    void OnCollisionEnter2D(Collision2D collision)
        {
            if(collision.gameObject == GameCore.BALL.gameObject)
            {
            
            maxScore.UpdateMaxScore(activeScore._activeScore); // обновляет макс рекорд
            
#if !UNITY_EDITOR && UNITY_WEBGL
                Progress.Instance.Save();
#endif
            CloseGlove();
                EndGame(); 
            }
        }

    private void EndGame()
    {
        


        GameCore.BALL.DeathBall();
        _UI.PlaySound();
        StartCoroutine(OpenUI(2));
    }
    IEnumerator OpenUI(int index)
    {
        yield return new WaitForSeconds(2f);
#if !UNITY_EDITOR && UNITY_WEBGL
        GameCore.YANDEX.ShowAdd();
#endif
        _UI.EnableDisableUI(index);
        GloveRestart();

    }

    private void CloseGlove()
    {
        _sr.sprite = _closeGlove;
        _rb.bodyType = RigidbodyType2D.Dynamic;
        _rb.gravityScale = 0.7f;
        _polygonCollider.enabled = false;
        _rb.AddForce(new Vector2(0, 150));
        _rb.freezeRotation = true;
    }

    private void GloveRestart()
    {
        transform.position = _startPointGlove;
        _sr.sprite = _openGlove;
        _rb.bodyType = RigidbodyType2D.Static;
        _rb.gravityScale = 0;
        _polygonCollider.enabled = true;
    }

}
