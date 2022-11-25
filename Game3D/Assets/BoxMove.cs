using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

public class BoxMove : MonoBehaviour
{
    [SerializeField] private float _height;
    [SerializeField] private int _numberOfCoints;
    [SerializeField] private string _name;
    [SerializeField] private Color _bodyColor;
    [SerializeField] private Vector3 _startPosition;
    [SerializeField] private Vector3 _startEulerAngles;
    [SerializeField] private bool _isAlive;

    [SerializeField] private Light _sun;
    [SerializeField] private Camera _camera;
    [SerializeField] private Transform _ball;
    //[SerializeField] private Object _ballColor;
    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = new Vector3(1, _height, 1);
        gameObject.name = _name;
        //gameObject.GetComponent<Renderer>().material.color = _bodyColor;
        transform.position = _startPosition;
        transform.eulerAngles = _startEulerAngles;
        gameObject.SetActive(_isAlive);

        _sun.intensity = 2;
        _sun.color = Color.cyan;
        //_camera.fieldOfView = 120;
    }

    // Update is called once per frame
    void Update()
    {

        //transform.eulerAngles = transform.position + new Vector3(0, 10, 0);
        //transform.localScale = new Vector3(1, 2, 4)
        _ball.position = transform.position + new Vector3(0, 0.5f, 0);
        if (Input.GetKey(KeyCode.W))
        {
            transform.eulerAngles -= new Vector3(0, 0, 0.5f);
            transform.position += new Vector3(0.03f, 0, 0);
            _camera.transform.position += new Vector3(0.03f, 0, 0);
            _ball.GetComponent<Renderer>().material.color = Color.green;
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.eulerAngles += new Vector3(0, 0, 0.5f);
            transform.position -= new Vector3(0.03f, 0, 0);
            _camera.transform.position -= new Vector3(0.03f, 0, 0);
            _ball.GetComponent<Renderer>().material.color = Color.red;
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.eulerAngles += new Vector3(0.5f, 0, 0);
            transform.position += new Vector3(0, 0, 0.03f);
            _ball.GetComponent<Renderer>().material.color = Color.blue;
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.eulerAngles -= new Vector3(0.5f, 0, 0);
            transform.position -= new Vector3(0, 0, 0.03f);
            _ball.GetComponent<Renderer>().material.color = Color.black;
        }
        if (Input.GetKey(KeyCode.Space))
        {
            transform.position += new Vector3(0, 0.03f, 0);
            _ball.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (Input.GetKey(KeyCode.Q))//это поворот
        {
            transform.eulerAngles -= new Vector3(0, 0, 0.5f); 
            transform.position += new Vector3(0.03f, 0, 0);
            _camera.transform.position += new Vector3(0.03f, 0, 0);
            _ball.GetComponent<Renderer>().material.color = Color.cyan;
        }
        if (transform.position.y > 0.94 && !(Input.GetKey(KeyCode.Space)))
        {
            transform.position -= new Vector3(0, 0.03f, 0);
        }
        if (Input.GetMouseButton(0))
        {
            transform.localScale *= 1.01f;
        }
        

        //_camera.transform.localEulerAngles = new Vector3(0, Input.mousePosition.x, 0);
        
    }
}
