using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLoader : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] GameObject _player;
    void Start()
    {

        if (PlayerController.instance == null)
        {
            Instantiate(_player);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
