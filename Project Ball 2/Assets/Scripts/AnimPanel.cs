using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AnimPanel : MonoBehaviour
{
    private Animator _Animator;

    void Start()
    {
        _Animator = GetComponent<Animator>();
    }
    public void OpenPanel()
    {
        _Animator.SetBool("Enable", true);
    }
    public void ClosePanel()
    {
        _Animator.SetBool("Enable", false);
    }
    
}
