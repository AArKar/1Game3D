using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private float _speed;
    private float _OldMousePositionX;
    private float _eularY;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _OldMousePositionX = Input.mousePosition.x;//����� �� ���� ������, ����� ��������� ������� ���� � ���������� �������
        }
        if (Input.GetMouseButton(0))
        {
            Vector3 newPosition = transform.position + transform.forward * Time.deltaTime * _speed;
            newPosition.x = Mathf.Clamp(newPosition.x, -2.5f, 2.5f);
            transform.position = newPosition;
            //transform.position += transform.forward * 0.02f * Time.deltaTime * _speed;//Time.deltaTime - ����� ������ �����

            float deltaX = Input.mousePosition.x - _OldMousePositionX; //��������� �� ���� ����
            _OldMousePositionX = Input.mousePosition.x;
            _eularY += deltaX;
            _eularY = Mathf.Clamp(_eularY, -70, 70);//����������� ��������
            transform.eulerAngles = new Vector3(0, _eularY, 0);
        }
        
    }
}
