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
        float circle = Time.time / period;//количество кругов за определенный временной период
        const float Tau = Mathf.PI * 2;//наше значение Тау - 2 Пи
        float rawSin = Mathf.Sin(circle * Tau);//наша синусоида, которая будет менять свои значения от -1 до 1 с течением времени,
                                               //так как время растет и делится на количество указанных кругов

        movementFactor = (rawSin +1f) / 2;//+1f нужно для того, чтобы наш movementFactor начинался с 0 и шел до 1, так как Sin идет от -1 до 1, потом мы / на 2,
                                          //чтобы значения были от 0 до 1, а не от 0 до 2
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
