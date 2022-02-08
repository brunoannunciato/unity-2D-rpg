using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D _body;
    float _speed = 5;
    static PlayerController _instance;
    Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _body = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        DontDestroyOnLoad(gameObject);


        if (_instance == null)
        {
            _instance = this;
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
    }
}
