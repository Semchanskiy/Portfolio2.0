using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraPort : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Vector3 cameraToObject = transform.position - Camera.main.transform.position;
        // отрицание потому что игровые объекты в данном случае находятся ниже камеры по оси y
        float distance = -Vector3.Project(cameraToObject, Camera.main.transform.forward).y;

        // вершины "среза" пирамиды видимости камеры на необходимом расстоянии от камеры
        Vector3 leftBot = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, distance));
        Vector3 rightTop = Camera.main.ViewportToWorldPoint(new Vector3(1, 1, distance));

        // границы в плоскости XZ, т.к. камера стоит выше остальных объектов
        float x_left = leftBot.x;
        float x_right = rightTop.x;
        float z_top = rightTop.z;
        float z_bot = leftBot.z;

        // ограничиваем объект в плоскости XZ
        Vector3 clampedPos = transform.position;
        clampedPos.x = Mathf.Clamp(clampedPos.x, x_left, x_right);
        clampedPos.z = Mathf.Clamp(clampedPos.z, z_bot, z_top);
        transform.position = clampedPos;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
