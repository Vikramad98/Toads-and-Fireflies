using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireflySpawner : MonoBehaviour
{
    [SerializeField]
    private Firefly[] Fireflies;

    public float spawnDelay;
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(Spawn());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator Spawn()
    {
        Firefly flyInstance = Instantiate(Fireflies[Random.Range(0, Fireflies.Length)], new Vector3(transform.position.x, transform.position.y + Random.Range(-2, 2)),Quaternion.identity);
        int power = Random.Range(2, 6);
        flyInstance.setup(power, transform.right);
        yield return new WaitForSeconds(Random.Range(0, 6));
        StartCoroutine(Spawn());
    }
}
