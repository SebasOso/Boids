using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boids : MonoBehaviour
{
   
    [Header("Boid Options")]
    [SerializeField] private BoidUnit boidUnitPrefab;
    [Range(5, 5000)]
    public int boidCount;
    [Range(10, 100)]
    public float spawnRange=30;
    public Vector2 speedRange;

    [Range(0, 10)]
    public float cohesionWeight=1;
    [Range(0, 10)]
    public float alignmentWeight=1;
    [Range(0, 10)]
    public float separationWeight = 1;

    [Range(0, 100)]
    public float boundsWeight = 1;
    [Range(0, 100)]
    public float obstacleWeight = 10;
    [Range(0, 10)]
    public float egoWeight = 1;


    public BoidUnit currUnit;
    private MeshRenderer boundMR;
    [SerializeField] LayerMask unitLayer;



    void Start()
    {
        // Generate Boids
        boundMR = GetComponentInChildren<MeshRenderer>();
        for (int i = 0; i < boidCount; i++)
        {
            Vector3 randomVec = Random.insideUnitSphere;
            randomVec *= spawnRange;
            Quaternion randomRot = Quaternion.Euler(0, Random.Range(0, 360f), 0);
            BoidUnit currUnit = Instantiate(boidUnitPrefab, this.transform.position+ randomVec, randomRot);
            currUnit.transform.SetParent(this.transform);
            currUnit.InitializeUnit(this,Random.Range(speedRange.x, speedRange.y),i);
        }
    }

}
