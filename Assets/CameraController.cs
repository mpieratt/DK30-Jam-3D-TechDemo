using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject player;

    private Vector3 offset;

    public float changePerspectiveOffset = 5.0f;
    public float changePerspectiveTilt = 90.0f;

    public float smooth = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        offset = transform.position - player.transform.position;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 changePerspectivePosition = new Vector3(0.0f, (Input.GetAxis("Fire1") * changePerspectiveOffset), 0.0f);
        Quaternion changePerspectiveRotation = Quaternion.Euler((Input.GetAxis("Fire1") * changePerspectiveTilt), 0.0f, 0.0f); 

        transform.position = player.transform.position + offset + changePerspectivePosition;
        transform.rotation = Quaternion.Slerp(transform.rotation, changePerspectiveRotation, Time.deltaTime * smooth);
    }
}
