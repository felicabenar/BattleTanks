using UnityEngine;
using Mirror;

public class TankGun : NetworkBehaviour
{

    [SerializeField] Transform bulletPrefab;
    [SerializeField] Transform bulletSpawnPoint;
   // [SerializeField] Vector3 bulletSpeed = Vector3.forward * 10f;
    [SerializeField] float bulletSpeed = 25f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (!isLocalPlayer) return;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ShootBullet();
            CmdShootBullet();
        }
    }

    void ShootBullet()
    {
        Transform bullet = Instantiate(bulletPrefab, bulletSpawnPoint.position, bulletSpawnPoint.rotation);
        bullet.GetComponent<Rigidbody>().linearVelocity = bullet.forward * bulletSpeed;
    }

[Command]
void CmdShootBullet()
{
    RpcShootBullet();
}

[ClientRpc(includeOwner = false)]
void RpcShootBullet()
{
    ShootBullet();
}

}
