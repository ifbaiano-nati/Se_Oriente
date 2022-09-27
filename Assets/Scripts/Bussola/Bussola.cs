using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Danndx 2021 (youtube.com/danndx)
From video: youtu.be/Gr90iGceBTQ
thanks - delete me! :) */

public class Bussola : MonoBehaviour
{
    private Player player;

    float tiltAngle = 90.0f;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
    }

    void Update()
    {
        if(player.speed != 0f)
        {
            float tiltAroundx = Input.GetAxis("Horizontal") * tiltAngle;
            float tiltAroundy = Input.GetAxis("Vertical") * tiltAngle;

            var angle = Mathf.Atan2(tiltAroundx, tiltAroundy) * Mathf.Rad2Deg;


            transform.rotation = Quaternion.AngleAxis(-angle, Vector3.forward);

        }
        
        
    }
}



