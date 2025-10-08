using UnityEngine;
using TMPro;
using Mirror;

public class PlayerNetworking : NetworkBehaviour
{
    
    [SyncVar (hook = nameof(HitMessage))]
    [SerializeField] int PlayerHealth = 100;

    [SyncVar (hook = nameof(UpdateName))] 
    [SerializeField] string playerName = "New Player";
    [SerializeField] Transform namePrefab, nameInstance;
    Vector3 nameOffset = new Vector3(0, 1.5f, 0);

    /*[SerializeField] TMP_InputField nameField;
    [SerializeField] Button nameButton; */

    void Awake()
    {
        nameInstance = Instantiate(namePrefab, transform.position + nameOffset, Quaternion.identity);
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(isLocalPlayer)
        {
            //CmdUpdateName("Loser");
            /*nameField = GameObject.FindWithTag("NameField").GetComponent<TMP_InputField>();
            nameButton = GameObject.FindWithTag("NameButton").GetComponent<Button>();*/
            NameChanger.onChangeName += CmdUpdateName;
        }    

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

    void LateUpdate()
    {
        nameInstance.transform.position = transform.position + nameOffset;
        nameInstance.transform.LookAt(Camera.main.transform);
        nameInstance.transform.Rotate(0f, 180f, 0f);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (!isServer) return;
        if (collision.gameObject.CompareTag("BulletTag"))
        {
            CmdChangeHealth(-10);
        }
    }

    [Command]
    void CmdUpdateName(string newName)
    {
        playerName = newName;
    }

    void UpdateName(string oldName, string newName)
    {
        nameInstance.GetComponent<TMP_Text>().text = newName;
    }

    [Command]
    void CmdChangeHealth(int damage)
    {
        PlayerHealth += damage;
    }

    void HitMessage(int oldHealth, int newHealth)
    {
        if (!isLocalPlayer) return;
        if (newHealth <= 0)
        {
            //RESET PLAYER
            Debug.Log("u suck");
        }
    }
}
