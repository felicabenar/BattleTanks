using UnityEngine;
using Mirror;

public class PlayerNetworking : NetworkBehaviour
{
    
    [SyncVar (hook = nameof(HitMessage))]
    [SerializeField] int PlayerHealth = 100;
    
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

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("BulletTag"))
        {
            CmdChangeHealth(10);
        }
    }

    [Command]
    void CmdChangeHealth(int damage)
    {
        PlayerHealth -= damage;
    }

    void HitMessage(int oldHealth, int newHealth)
    {
        if (newHealth <= 0)
        {
            //RESET PLAYER
            Debug.Log("u suck");
        }
    }
}
