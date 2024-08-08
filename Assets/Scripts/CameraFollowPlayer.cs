using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{

    public GameObject player;
    private float followDelay = 0.2f;
    private Vector2 refVel = Vector2.zero;
    // private Queue<Vector3> playerPos;
    private float cameraZ = -10f;

    // Start is called before the first frame update
    void Start()
    {
        cameraZ = gameObject.transform.position.z;
        // playerPos = new Queue<Vector3>();
        // if(player == null){
        //     player = GameObject.FindWithTag("Player");
        // }
        // for(int i = 0; i <= followDelay; i++){
        //     playerPos.Enqueue(new Vector3(player.transform.position.x, player.transform.position.y, cameraZ));
        // }
    }

    void Update(){
        // followPlayer();
        Vector2 smooth2D = Vector2.SmoothDamp(transform.position, player.transform.position, ref refVel, followDelay);
        transform.position = new Vector3(smooth2D.x, smooth2D.y, cameraZ);
    }

    void followPlayer(){
        // gameObject.transform.position = playerPos.Dequeue();
        // playerPos.Enqueue(new Vector3(player.transform.position.x, player.transform.position.y, cameraZ));

    }
}
