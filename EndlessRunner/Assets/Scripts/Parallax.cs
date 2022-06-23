using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{

    public Camera mainCam;
    public GameObject player;
    public float ParallaxEffect = 0f;
    [SerializeField]
    private float length;


    private float startPos;

    void moveBg() 
    {
        float dist = mainCam.transform.position.x * ParallaxEffect;
        float camEffectiveDist = mainCam.transform.position.x * (1 - ParallaxEffect);

        transform.position = new Vector3(startPos + dist, transform.position.y, transform.position.z);

        if (camEffectiveDist > startPos + length) {
            startPos += length;
        }
        else if (camEffectiveDist < startPos - length) {
            startPos -= length;
        }

    }

    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position.x;
        length = GetComponent<SpriteRenderer>().bounds.size.x - startPos;
    }

    // Update is called once per frame
    void Update()
    {
        moveBg();
    }
}
