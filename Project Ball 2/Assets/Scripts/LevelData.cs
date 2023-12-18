using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelData : MonoBehaviour
{
    [SerializeField] private LevelUI levelUI;
    [SerializeField] private ParticleSystem FireWork;
    private TextEnemyCount TextEnemyCount;
    public int CountSpawnedEnemys;
    public int CountDestroyEnemys;
    public int maxBigEnemiesInLevel;
    public float MaxTimer;
    public float MinTimer;

    float x_left;
    float x_right;
    float z_top;
    float z_bot;

    private void Start()
    {
        TextEnemyCount = FindObjectOfType<TextEnemyCount>();
        TextEnemyCount.UpdateText(CountDestroyEnemys);
    }

    private void StartFireWork()
    {
        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        x_left = leftBot.x;
        x_right = rightTop.x;
        z_top = rightTop.z;
        z_bot = leftBot.z;
        StartCoroutine(NextFireWork());
    }

    IEnumerator NextFireWork()
    {
        yield return new WaitForSecondsRealtime(Random.Range(0.1f,1));
        Instantiate(FireWork, new Vector3(Random.Range(x_left, x_right), 5, Random.Range(z_bot, z_top)),
            Quaternion.identity);
        StartCoroutine(NextFireWork());
    }
    public void EnemyDestroyed()
    {
        CountDestroyEnemys--;
        TextEnemyCount.UpdateText(CountDestroyEnemys);
        if (CountDestroyEnemys == 0)
        {
            levelUI.OpenWinPanel();
            StartFireWork();
        }
    }

    public void EnemySpawned()
    {
        CountSpawnedEnemys--;
    }

}
