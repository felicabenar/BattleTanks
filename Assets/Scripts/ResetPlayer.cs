using UnityEngine;

public class ResetPlayer : MonoBehaviour
{

    void OnCollisionEnter(Collision collision)
    {
        Transform tform = collision.transform;
        if (tform.GetComponent<TankController>())
        {
            TankController tc = tform.GetComponent<TankController>();
            tform.position = tc.startPos;
            tform.localEulerAngles = tc.transform.localEulerAngles;
            tform.GetComponent<Rigidbody>().linearVelocity = Vector3.zero;
            tform.localEulerAngles = tc.startRot;
        }       
    }

}