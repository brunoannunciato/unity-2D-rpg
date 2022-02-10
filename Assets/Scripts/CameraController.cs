using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CameraController : MonoBehaviour
{

    [SerializeField] Tilemap _map;
    Vector3 minBoundMap;
    Vector3 maxBoundMap;

    Transform target;
    void Start()
    {
        minBoundMap = _map.localBounds.min;
        maxBoundMap = _map.localBounds.max;

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
