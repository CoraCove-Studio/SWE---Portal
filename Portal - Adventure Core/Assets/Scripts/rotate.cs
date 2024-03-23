using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour
{
    [SerializeField] private float speed = 3;

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Time.deltaTime * speed * Vector3.forward);
    }
}
