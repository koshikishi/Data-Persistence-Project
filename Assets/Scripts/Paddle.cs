using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    public float Speed;
    public float MaxMovement = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        Speed = SettingsManager.Instance.PaddleSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        float input = Input.GetAxis("Horizontal");

        Vector3 pos = transform.position;
        pos.x += input * Speed * Time.deltaTime;

        if (pos.x > MaxMovement)
        {
            pos.x = MaxMovement;
        }
        else if (pos.x < -MaxMovement)
        {
            pos.x = -MaxMovement;
        }

        transform.position = pos;
    }
}
