using UnityEngine;
public class bobBehaviour : MonoBehaviour
{
    public static int cpt_death = 0; 
    public GameObject fx;

    public GameObject worldObject;

    public AudioSource aud;

    void Start()
    {
        aud = GameObject.Find("Audio").GetComponent<AudioSource>();
        worldObject = GameObject.Find("World");
    }
    void Update()
    {

    }
    void OnTriggerEnter(Collider other)
    { // OnCollisionEnter
        if (other.tag == "Player")
        {
            cpt_death++;
            Instantiate(fx, transform.position, Quaternion.identity);
            aud.Play();
            worldObject.SendMessage("AddHit");
            Destroy(gameObject);
        }
    }
}