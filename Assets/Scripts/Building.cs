using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public struct BuildingUpdateJob : IJobParallelFor
{
    public NativeArray<Building.Data> BuildingDataArray;
    public void Execute(int index)
    {
        Building.Data data = BuildingDataArray[index];
        data.UpdatePowerUsage();
        BuildingDataArray[index] = data;
    }
}

public class Building : MonoBehaviour
{
    public struct Data
    {
        private int _tentant;
        private Unity.Mathematics.Random _random;
        public float PowerUsage { get; private set; }

        public Data(Building building)
        {
            _random = new((uint)DateTime.Now.ToFileTimeUtc());
            _tentant = building._floors * _random.NextInt(50, 200);
            PowerUsage = 0;
        }

        public void UpdatePowerUsage()
        {
            PowerUsage = 0;
            for (int i = 0; i < _tentant; i++)
            {
                PowerUsage += _random.NextFloat(1f, 5f);
            }
        }
    }

    [SerializeField]
    private int _floors;
    
}
