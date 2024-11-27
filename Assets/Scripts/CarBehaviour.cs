using UnityEngine;
using System;

public class CarBehaviour : MonoBehaviour
{
    public Transform[] wayPoints;
    public Transform[] wayPoints2;
    public Transform[] temp;
    public int target;
    public float carSpeed;

    // Start is called before the first frame update
    void Start()
    {
        temp = wayPoints;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, temp[target].position, carSpeed * Time.deltaTime);

        if (transform.position == temp[target].position)
        {
            if (target == temp.Length - 1)
            {
                target = 0;
                transform.Rotate(0f, 0f, -45f);
            }
            else
            {
                target++;
                transform.Rotate(0f, 0f, -45f);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (temp[target] == wayPoints[target])
            {
                temp[target] = wayPoints2[target];
                temp = wayPoints2;
            }
            else
            {
                temp[target] = wayPoints[target];
                temp = wayPoints;
            }
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Orange"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
        }
    }
}