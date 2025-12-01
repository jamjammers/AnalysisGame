using System;
using System.Security.Cryptography;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class prism : MonoBehaviour
{
    public float rotationSpeed = 10;
    public float moveSpeed = 5;
    public State change = State.IDLE;

    float tweenTarget = 0; // end tween rotation
    public float transformTarget = 0; // end transform position

    // rotation offset going into the transform
    float transformRotation;

    // rotation offset after the transform
    public float endRotation = 45;

    public Material afterMaterial;

    public float textDecayRate = 2;
    public GameObject textObj;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transformRotation = transformTarget/moveSpeed * rotationSpeed;
        Debug.Log(transformRotation);
    }

    // Update is called once per frame
    void Update()
    {
        switch (change)
        {
            case State.IDLE:
                transform.Rotate(Vector3.up,rotationSpeed * Time.deltaTime);
                break;

            case State.TWEEN:
                float angle = transform.rotation.eulerAngles.y;
                if (angle + rotationSpeed * Time.deltaTime >= tweenTarget)
                {
                    Vector3 euler = transform.rotation.eulerAngles;
                    euler.y = (float)tweenTarget;
                    transform.rotation = Quaternion.Euler(euler);
                    change = State.TRANSFORM;
                    break;
                }
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                break;

            case State.TRANSFORM:
                transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
                transform.position += Vector3.left * moveSpeed * Time.deltaTime;  //rotation = target/speed * speed
                if (transform.position.x <= transformTarget)
                {
                    Vector3 pos = transform.position;
                    pos.x = (float)transformTarget;
                    transform.position = pos;
                    Vector3 euler = transform.rotation.eulerAngles;
                    euler.y = endRotation;
                    transform.rotation = Quaternion.Euler(euler);

                    GetComponent<Renderer>().material = afterMaterial;
                    change = State.DONE;
                }
                
                break;

            case State.DONE:
                // transform.Rotate(Vector3.up,rotationSpeed * Time.deltaTime);

                break;
        }
    }

    public void start()
    {
        change = State.TWEEN;
        tweenTarget = ((float) Math.Ceiling((transform.rotation.eulerAngles.y-transformRotation-endRotation) / 90f) * 90f+transformRotation+endRotation)%360f;
        textObj.GetComponent<button>().show();
    }

    public enum State
    {
        IDLE,
        TWEEN,
        TRANSFORM,
        DONE
    }
}
