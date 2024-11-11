using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<GameObject> locations = new List<GameObject>();
    [SerializeField] Transform player;

    float floorLength = 106.3f;
    float length = 106.3f;
    int floorCount = 4;
    [SerializeField] GameObject shield;



    // Start is called before the first frame update
    void Start()
    {
        Instantiate(locations[0], transform.forward, transform.rotation);
        for (int i = 0; i < floorCount; i++)
        {
            GenerateLocation();
        }
        GenerateObject();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.z > floorLength - length * floorCount)
        {
            GenerateLocation();
        }

    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void HomePage()
    {
        SceneManager.LoadScene(0);
    }

    void GenerateLocation()
    {
        Instantiate(locations[Random.Range(0, locations.Count)], transform.forward * floorLength , transform.rotation);
        floorLength += 106.3f;
    }

    void GenerateObject()
    {
        float distance = Random.Range(100, 200);
        Instantiate(shield, player.position + new Vector3(0,2,distance), transform.rotation);
        Invoke("GenerateObject", Random.Range(20,30));
    }





}
