using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _body;
    float _speed = 5;
    public static PlayerController instance;
    public string areaTransitionName;
    Animator _anim;
    Vector3 minBoundMap;
    Vector3 maxBoundMap;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);


        if (instance == null)
        {
            instance = this;
        } else
        {
            Destroy(gameObject);
        }

    }

    // Update is called once per frame
    void Update()
    {
        _body.velocity = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")) * _speed;

        _anim.SetFloat("MoveY", _body.velocity.y);
        _anim.SetFloat("MoveX", _body.velocity.x);

        if (Input.GetAxisRaw("Horizontal") != 0 || Input.GetAxisRaw("Vertical") != 0)
        {
            _anim.SetFloat("lastMoveX", Input.GetAxisRaw("Horizontal"));
            _anim.SetFloat("lastMoveY", Input.GetAxisRaw("Vertical"));
        }

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, minBoundMap.x, maxBoundMap.x), Mathf.Clamp(transform.position.y, minBoundMap.y, maxBoundMap.y), transform.position.z);
    }

    public void setBounds(Vector3 minBound, Vector3 maxBound)
    {
        minBoundMap = minBound + new Vector3(.5f, .5f, 0);
        maxBoundMap = maxBound + new Vector3(-.5f, -.5f, 0);
    }
}
