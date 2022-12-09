using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _OldMousePositionX;
    private float _eularY;
    [SerializeField] Animator _animator;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _OldMousePositionX = Input.mousePosition.x;//чтобы не было рывков, после опускания клавиши мыши и следующего нажатия
            _animator.SetBool("Run", true);
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
            newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);
            transform.position = newPosition;
            //transform.position += transform.forward * 0.02f * Time.deltaTime * _speed;//Time.deltaTime - время одного кадра

            float deltaX = Input.mousePosition.x - _OldMousePositionX; //изменение за один кадр
            _OldMousePositionX = Input.mousePosition.x;
            _eularY += deltaX;
            _eularY = Mathf.Clamp(_eularY, -70, 70);//ограничение велечины
            transform.eulerAngles = new Vector3(0, _eularY, 0);
        }
        
        if(Input.GetMouseButtonUp(0))
        {
            _animator.SetBool("Run", false);
        }
    }
}
