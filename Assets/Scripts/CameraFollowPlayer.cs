using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// gameObject follows player with a slight smoothing factor determined by followDelay

public class CameraFollowPlayer : MonoBehaviour
{

    public GameObject player;
    private float followDelay = 0.2f;
    private Vector2 refVel = Vector2.zero;
    private float cameraZ = -10f;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
        cameraZ = gameObject.transform.position.z;
    }

    void Update(){
        Vector2 smooth2D = Vector2.SmoothDamp(transform.position, player.transform.position, ref refVel, followDelay);
        transform.position = new Vector3(smooth2D.x, smooth2D.y, cameraZ);
    }
}
