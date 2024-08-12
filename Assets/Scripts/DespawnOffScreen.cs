using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DespawnOffScreen : MonoBehaviour
{
    private float timeGone = 0f;

    // # of seconds off screen until GameObject is destroyed
    public float timeToDespawn = 10f;
    private Renderer m_Renderer;
    // Start is called before the first frame update
    void Start()
    {
        m_Renderer = GetComponent<Renderer>();
        timeGone = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!m_Renderer.isVisible){
            timeGone += Time.deltaTime;
            if(timeGone >= timeToDespawn){
                Destroy(gameObject);
            }
        } else{
            timeGone = 0;
        }
    }
}
