using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Portal : MonoBehaviour
{
    [SerializeField] int _nextMapId;
    [SerializeField] string _areaTransitionName;
    public EntranceMap entranceMap;
    float timeToWaitForFade = 1.5f;
    bool shouldWaitFade = false;

    // Start is called before the first frame update
    void Start()
    {
        entranceMap.areaTransitionName = _areaTransitionName;
    }

    // Update is called once per frame
    void Update()
    {
        if (shouldWaitFade == true)
        {
            timeToWaitForFade -= Time.deltaTime;
            UiFade.instance.FadeToBlack();

            if (timeToWaitForFade <= 0)
            {
                shouldWaitFade = false;
                SceneManager.LoadScene(_nextMapId);
            }
        }
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log(other);
        if (other.tag == "Player")
        {
            shouldWaitFade = true;

            PlayerController.instance.areaTransitionName = _areaTransitionName;
        }
    }
}
