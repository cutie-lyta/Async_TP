using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Collections;
using Unity.Jobs;
using UnityEngine;

public class BuildingManager : MonoBehaviour
{
    public List<Building> Buildings;
    
    private NativeArray<Building.Data> _buildingDataArray;
    private BuildingUpdateJob _job;
    private JobHandle _jobHandler;
    private void Awake()
    {
        Buildings = GameObject.FindObjectsByType<Building>(FindObjectsSortMode.None).ToList();
        
        _buildingDataArray = new NativeArray<Building.Data>(Buildings.Count, Allocator.Persistent);
        for (int i = 0; i < Buildings.Count; i++)
        {
            _buildingDataArray[i] = new (Buildings[i]);
        }

        _job = new()
        {
            BuildingDataArray = _buildingDataArray,
        };
    }

    private void Update()
    {
        _jobHandler = _job.Schedule(Buildings.Count, 1);
    }

    private void LateUpdate()
    {
        _jobHandler.Complete();
    }

    private void OnDestroy()
    {
        _buildingDataArray.Dispose();
    }
}
