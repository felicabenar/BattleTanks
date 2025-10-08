using Unity.VisualScripting;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;
//using UnityEngine.UIElements;

public class ChaseCamera : MonoBehaviour
{
    public static Transform player;
    [SerializeField] float distance = 12f;
    [SerializeField] float height = 6f;
    [SerializeField] Vector3 offset = new Vector3(0, 1, 0);

    [SerializeField] float moveSpeed = 1f;
    [SerializeField] float rotSpeed = 3f;

    void FixedUpdate()
    {
        if (player == null) return;

        Vector3 lookPos = player.position + offset;
        Vector3 relativePos = lookPos - transform.position;
        Quaternion rot = Quaternion.LookRotation(relativePos);

        transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.fixedDeltaTime * rotSpeed);

        Vector3 targetPos = player.position + player.up * height - player.forward * distance;

        transform.position = Vector3.Lerp(transform.position, targetPos, Time.fixedDeltaTime * moveSpeed);

        //transform.parent = player.transform;

    }
}
