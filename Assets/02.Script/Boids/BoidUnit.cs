using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoidUnit : MonoBehaviour
{
    public void InitializeUnit(Boids _boids, float _speed, int _myIndex)
    {
        BoidController.Instance.myBoids = _boids;
        BoidController.Instance.speed = _speed;
        BoidController.Instance.findNeighbourCoroutine = StartCoroutine("FindNeighbourCoroutine");
        BoidController.Instance.calculateEgoVectorCoroutine = StartCoroutine("CalculateEgoVectorCoroutine");
    }
    void Update()
    {
       BoidController.Instance.Update();
    }
}
