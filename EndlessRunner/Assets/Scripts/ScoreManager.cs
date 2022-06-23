using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    [SerializeField]
    private float curScore = 0;
    [SerializeField]
    private float coinValue;
    [SerializeField]
    private TextMeshProUGUI Score;

    public void coinPicked() 
    {
        curScore += coinValue;
        Score.text = curScore.ToString();
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
