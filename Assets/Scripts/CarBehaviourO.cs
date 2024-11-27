using UnityEngine;
using UnityEngine.SceneManagement;

public class CarBehaviourO : MonoBehaviour
{
    public Transform[] wayPoints;
    public Transform[] wayPoints2;
    public Transform[] temp;
    public int target;
    public float carSpeed;
    public float timeToChangeLane;
    private float counter;
    
    // Start is called before the first frame update
    void Start()
    {
        temp = wayPoints;
        counter = timeToChangeLane;
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
                transform.Rotate(0f, 0f, 45f);
            }
            else
            {
                target++;
                transform.Rotate(0f, 0f, 45f);
            }
        }
        
        if (counter > 0)
        {
            if (temp[target] == wayPoints[target] && counter < 1.1f)
            {
                temp[target] = wayPoints2[target];
                temp = wayPoints2;
                counter -= Time.deltaTime;
            }
            else if (temp[target] == wayPoints2[target] && counter < 2.1f)
            {
                temp[target] = wayPoints[target];
                temp = wayPoints;
                counter -= Time.deltaTime;
            }
            else
            {
                counter -= Time.deltaTime;
            }
        }

        if (counter <= 0)
        {
            counter = timeToChangeLane;
        }
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Blue"))
        {
            gameObject.SetActive(false);
            other.gameObject.SetActive(false);
            SceneManager.LoadScene("SampleScene");
        }
    }
}
