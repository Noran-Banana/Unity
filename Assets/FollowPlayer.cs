using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform player;

    public float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = Vector3.Lerp(
            transform.position,
            player.position,
            speed * Time.deltaTime
        );

        targetPosition.z = transform.position.z;

        transform.position = targetPosition;
    }
}
