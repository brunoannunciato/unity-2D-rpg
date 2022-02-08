using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntranceMap : MonoBehaviour
{
    public string areaTransitionName;
    // Start is called before the first frame update
    void Start()
    {
        if (areaTransitionName == PlayerController.instance.areaTransitionName)
        {
            Debug.Log("HITOU!");
            PlayerController.instance.transform.position = transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
