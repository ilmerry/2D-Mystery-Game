using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransferMap : MonoBehaviour
{
    public string transferMapName;  //이동할 맵의 이름

    public Transform target;

    private PlayerManager thePlayer;

    // Start is called before the first frame update
    void Start()
    {
        
        thePlayer = FindObjectOfType<PlayerManager>();
    }

    private void OnTriggerEnter2D(Collider2D collison)
    {
        if(collison.gameObject.name == "눈송앞모습_0")
        {
            thePlayer.currentMapName = transferMapName;
            SceneManager.LoadScene(transferMapName);
            thePlayer.transform.position = target.transform.position;

        }
    }
}
