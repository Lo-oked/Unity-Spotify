using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CircleDancer : MonoBehaviour
{
    public int count = 10;
    public float radius = 5f;
    public GameObject prefab;
    public float rotatespeed;
    public float sensitivity;
    void Start()
    {
        for (float i = 0; i < count; i++)
        {
            var angle = i / count * Mathf.PI * 2;
            var x = Mathf.Cos(angle);
            var y = Mathf.Sin(angle);
            var pos = new Vector3(x, y, 0) * radius;

            var obj = Instantiate(prefab, pos, Quaternion.identity,transform);
            obj.transform.LookAt(transform);
            
        }
        Analyzer.onVolumeChanged.AddListener(dance);
    }

    void dance(float volume)
    {
        var intensity = Mathf.Pow(volume, sensitivity);
        transform.Rotate(0, 0, intensity * Time.deltaTime * rotatespeed);
        transform.localScale = Vector3.one * intensity;
    }
}
