using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testParallax : MonoBehaviour
{

   // public Transform target;
    //public Transform cameraTarget;
    //public Vector3 offset;
    [Range(1, 10)]
    public float smoothFactor;
    public GameObject player;
    [SerializeField]
    private float yOffset;



    private void FixedUpdate()
    {
        Follow();
    }

    void Follow()
    {
        Vector3 targetPosition = new Vector3 (player.transform.position.x, player.transform.position.y + yOffset, transform.position.z);
        Vector3 smoothCam = Vector3.Lerp(transform.position, targetPosition, smoothFactor * Time.deltaTime);
        transform.position = smoothCam;
    }

    private void LateUpdate()
    {
        
    }

    // Update is called once per frame

}
