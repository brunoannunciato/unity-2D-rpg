using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    [SerializeField] Tilemap _map;
    Vector3 minBoundMap;
    Vector3 maxBoundMap;
    
    float halfWidth;
    float halfHeight;

    Transform target;
    void Start()
    {
        halfHeight = Camera.main.orthographicSize;
        halfWidth = halfHeight * Camera.main.aspect;

        minBoundMap = _map.localBounds.min + new Vector3(halfWidth, halfHeight, 0);
        maxBoundMap = _map.localBounds.max + new Vector3(-halfWidth, -halfHeight, 0);

        target = PlayerController.instance.transform;
        Debug.Log(target);
    }

    // Update is called once per frame
    void LateUpdate()
    {
        //transform.position = new Vector3(target.position.x, target.position.y, transform.position.z);
        transform.position = new Vector3(Mathf.Clamp(target.position.x, minBoundMap.x, maxBoundMap.x), Mathf.Clamp(target.position.y, minBoundMap.y, maxBoundMap.y), transform.position.z);
    }
}
