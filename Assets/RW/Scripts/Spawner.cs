using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public List<GameObject> asteroids = new List<GameObject>();

    [SerializeField]
    private GameObject asteroid1;
    [SerializeField]
    private GameObject asteroid2;
    [SerializeField]
    private GameObject asteroid3;
    [SerializeField]
    private GameObject asteroid4;

    public void BeginSpawning()
    {
        StartCoroutine("Spawn");
    }

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(0.4f);

        SpawnAsteroid();
        StartCoroutine("Spawn");
    }

    public GameObject SpawnAsteroid()
    {
        int random = Random.Range(1, 5);
        GameObject asteroid;
        switch (random)
        {
            case 1:
                asteroid = Instantiate(asteroid1);
                break;
            case 2:
                asteroid = Instantiate(asteroid2);
                break;
            case 3:
                asteroid = Instantiate(asteroid3);
                break;
            case 4:
                asteroid = Instantiate(asteroid4);
                break;
            default:
                asteroid = Instantiate(asteroid1);
                break;
        }

        asteroid.SetActive(true);
        float xPos = Random.Range(-8.0f, 8.0f);

        // Spawn asteroid just above top of screen at a random point along x-axis
        asteroid.transform.position = new Vector3(xPos, 7.35f, 0);

        asteroids.Add(asteroid);

        return asteroid;
    }

    public void ClearAsteroids()
    {
        foreach(GameObject asteroid in asteroids)
        {
            Destroy(asteroid);
        }

        asteroids.Clear();
    }

    public void StopSpawning()
    {
        StopCoroutine("Spawn");
    }
}
