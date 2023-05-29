using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oscillator : MonoBehaviour
{
    Vector3 startingPosition;
    [SerializeField] Vector3 movementVector;
    float movementFactor;
    [SerializeField] float period = 5f;
    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(period>=Mathf.Epsilon)
        {
        float circle = Time.time / period;//���������� ������ �� ������������ ��������� ������
        const float Tau = Mathf.PI * 2;//���� �������� ��� - 2 ��
        float rawSin = Mathf.Sin(circle * Tau);//���� ���������, ������� ����� ������ ���� �������� �� -1 �� 1 � �������� �������,
                                               //��� ��� ����� ������ � ������� �� ���������� ��������� ������

        movementFactor = (rawSin +1f) / 2;//+1f ����� ��� ����, ����� ��� movementFactor ��������� � 0 � ��� �� 1, ��� ��� Sin ���� �� -1 �� 1, ����� �� / �� 2,
                                          //����� �������� ���� �� 0 �� 1, � �� �� 0 �� 2
        }
        else
        {
            Debug.Log("Error,you try to devide oscillating period by zero!");
            return;
        }
        Vector3 offset = movementVector * movementFactor;
        transform.position = startingPosition + offset;
    }
}   
