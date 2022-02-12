using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiFade : MonoBehaviour
{
    [SerializeField] Image _fadeImage;
    [SerializeField] bool _shouldFadeFromBlack, _shouldFadeToBlack;
    float _fadeSpeed = 1.5f;

    public static UiFade instance;

    void Start()
    {
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (_shouldFadeToBlack == true)
        {
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, Mathf.MoveTowards(_fadeImage.color.a, 1f, _fadeSpeed * Time.deltaTime));

            if (_fadeImage.color.a == 1f)
            {
                _shouldFadeToBlack = false;
            }
        }

        if (_shouldFadeFromBlack == true)
        {
            _fadeImage.color = new Color(_fadeImage.color.r, _fadeImage.color.g, _fadeImage.color.b, Mathf.MoveTowards(_fadeImage.color.a, 0, _fadeSpeed * Time.deltaTime));

            if (_fadeImage.color.a == 0f)
            {
                _shouldFadeFromBlack = false;
            }
        }
    }

    public void FadeToBlack()
    {
        _shouldFadeToBlack = true;
    }

    public void FadeFromBlack()
    {
        _shouldFadeFromBlack = true;
    }
}
