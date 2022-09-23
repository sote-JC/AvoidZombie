using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject[] zombiePrefabs;
    public GameObject walkingZombie;
    public TextMeshProUGUI waveCount;
    public GameObject gameOverScene;
    public Button restartButton;
    public TextMeshProUGUI playerLife;
    private PlayerController playerController;
    private float XRange = 22;
    private float spawnPosZ = 17.5f;
    public int zombieWave = 1;
    private int zombiesWithoutWalkingCount;
    // Start is called before the first frame update
    void Start()
    {
        playerController = GameObject.Find("Player").GetComponent<PlayerController>();
        SpawnZombie(1);
        SpawnWalkingZombie();
    }

    // Update is called once per frame
    void Update()
    {
        zombiesWithoutWalkingCount = GameObject.FindGameObjectsWithTag("OtherZombies").Length;

        if (zombiesWithoutWalkingCount == 0 && !playerController.isGameOver)
        {
            zombieWave++;
            SpawnZombie(zombieWave);
            SpawnWalkingZombie();
        }

        if (playerController.isGameOver)
        {
            gameOverScene.gameObject.SetActive(true);
        }

        playerLife.text = "Life " + playerController.life;
    }

    void SpawnZombie(int wave)
    {
        StartCoroutine(SpawnZombies(wave));
    }

    void SpawnWalkingZombie()
    {
        Vector3 spawnPos = new Vector3(Random.Range(-XRange, XRange), 0, spawnPosZ);
        Instantiate(walkingZombie, spawnPos, walkingZombie.transform.rotation);
    }

    IEnumerator SpawnZombies(int wave)
    {
        waveCount.text = "Wave " + wave;
        int zombieCount = wave * 5;
        for (int i = 0; i < zombieCount; i++)
        {
            Vector3 spawnPos = new Vector3(Random.Range(-XRange, XRange), 0, spawnPosZ);
            int zombieIndex = Random.Range(0, zombiePrefabs.Length);
            Instantiate(zombiePrefabs[zombieIndex], spawnPos, zombiePrefabs[zombieIndex].transform.rotation);
            yield return new WaitForSeconds(1.5f / wave);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
