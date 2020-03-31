using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private float _speed = 3.5f;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = new Vector3(0, 0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        CalculateMovement();
    }

    private void CalculateMovement()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");
        transform.Translate((Vector3.right * horizontal + Vector3.up * vertical) * _speed * Time.deltaTime);
        transform.position = new Vector3(transform.position.x > 11.3f ? -11.3f : transform.position.x < -11.3f ? 11.3f : transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0f), 0f);
    }
}
