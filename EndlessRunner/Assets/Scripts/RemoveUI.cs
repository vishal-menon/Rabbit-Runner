using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class RemoveUI : MonoBehaviour
{

    public GameObject PressSpace;
    [SerializeField]
    private Animator _animator;
    [SerializeField]
    private Animator score_animator;

    public void dText()
    {
        _animator.Play("TextWarpInto");
        Invoke(nameof(disableText), 0.25f);
    }

    public void disableText()
    {
        PressSpace.SetActive(false);
        showScore();
    }

    public void showScore() 
    {
        score_animator.Play("InitScore");
    }

    public void enableText()
    {
        PressSpace.SetActive(true);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
