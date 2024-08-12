using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

// Manages the icons for the player's life.

public class CanvasLifeManager : MonoBehaviour
{

    public GameObject player;

    private List<GameObject> lifeObjects = new List<GameObject>();

    public GameObject lifePrefab;

    // Start is called before the first frame update
    void Start()
    {
        if(player == null){
            player = GameObject.FindWithTag("Player");
        }
    }

    public void gainLife(){
        if(lifeObjects.Count() == 0){
            GameObject newLife = Instantiate(lifePrefab, gameObject.transform);
            lifeObjects.Add(newLife);
        } else{
            GameObject newLife = Instantiate(lifePrefab, lifeObjects.Last().transform.position + new Vector3(lifeObjects.Last().GetComponent<RectTransform>().sizeDelta.x, 0, 0), Quaternion.identity, gameObject.transform);
            lifeObjects.Add(newLife);
        }
    }

    public void loseLife(){
        if(lifeObjects.Count > 0){
            Destroy(lifeObjects.Last());
            lifeObjects.RemoveAt(lifeObjects.Count() - 1);
        } else{
            Debug.Log("Error: Attempted to lose a life with no lives left to lose");
        }
    }
}
