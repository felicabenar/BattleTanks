using UnityEngine;
using Mirror;

public class PlayerNetworking : NetworkBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GetComponent<TankController>().enabled = isLocalPlayer;

        if (isLocalPlayer)
        {
            ChaseCamera.player = transform;
            foreach (Transform child in transform)
            {
                GetComponent<Renderer>().material.color = Color.white;
                child.GetComponent<Renderer>().material.color = Color.white;
            }
        }
        else
        {
            foreach (Transform child in transform)
            {
                GetComponent<Renderer>().material.color = Color.red;
                child.GetComponent<Renderer>().material.color = Color.red;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
