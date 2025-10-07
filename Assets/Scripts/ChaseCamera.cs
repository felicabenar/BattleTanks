using UnityEngine;
using UnityEngine.UIElements;

public class ChaseCamera : MonoBehaviour
{
    public static Transform player;
    public float distance = 8f;
    public float height = 3f;
    Vector3 offset = new Vector3(0, 1, 0);

    float moveSpeed = 1f;
    float rotSpeed = 3f;

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 lookPos = player.position + offset;
        Vector3 relativePos = lookPos - transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * rotSpeed);

        Vector3 targetPos = player.position + player.up * height - player.forward;

        //transform.parent = player.transform;

    }
}
