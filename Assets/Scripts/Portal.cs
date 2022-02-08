using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int _nextMapId;
    [SerializeField] string _areaTransitionName;
    public EntranceMap entranceMap;
    // Start is called before the first frame update
    void Start()
    {
        entranceMap.areaTransitionName = _areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            SceneManager.LoadScene(_nextMapId);
            PlayerController.instance.areaTransitionName = _areaTransitionName;
        }
    }
}
