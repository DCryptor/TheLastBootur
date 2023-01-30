using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            Vector3 follow_position = new Vector3(transform.position.x, transform.position.y, target.position.z + 1);
            transform.position = Vector3.Slerp(transform.position, follow_position, 5 * Time.deltaTime);
        }

    }
}
