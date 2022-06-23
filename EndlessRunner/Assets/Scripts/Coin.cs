using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Coin : MonoBehaviour
{
    public UnityEvent coinPicked;
    public Animator _animator;
    public GameObject gameManager;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            coinPicked?.Invoke();
            _animator.Play("coinPickUp");
            Destroy(gameObject, 0.16f);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Debug.Log("lol");
        gameManager = GameObject.FindGameObjectWithTag("GameManager");
        coinPicked.AddListener(gameManager.GetComponent<ScoreManager>().coinPicked);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
