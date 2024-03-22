using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
   [SerializeField] private Transform target;
   [SerializeField] private Vector3 offset;

   void LateUpdate()
   {
        FollowPlayer();
   }

   void FollowPlayer()
   {
        transform.position = target.TransformPoint(offset);
        transform.rotation = target.rotation;
   }
}
