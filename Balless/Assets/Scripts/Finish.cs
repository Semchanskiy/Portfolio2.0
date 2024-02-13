using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    private UIBalless _UI;
    private AudioSource _soundFinish;
    [SerializeField] private MaxScore maxScore;
    [SerializeField] private ActiveScore activeScore;
    void Start() 
    {
        _UI = FindAnyObjectByType<UIBalless>();
        _soundFinish = GetComponent<AudioSource>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject == GameCore.BALL.gameObject)
        {
            maxScore.UpdateMaxScore(activeScore._activeScore);
            Progress.Instance.Save();

            StartCoroutine(OpenUI(5));
        }
    }

    IEnumerator OpenUI(int index)
    {
        yield return new WaitForSeconds(0f);
        _soundFinish.Play();
        _UI.EnableDisableUI(index);

    }

}
