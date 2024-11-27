using System.Reflection;
using UnityEngine;

public class BuildingBuilder : MonoBehaviour
{
    [SerializeField]
    private int _numOfBuildings;
    
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < _numOfBuildings; i++)
        {
            GameObject obj = new GameObject();
            var b = obj.AddComponent<Building>();
            b.GetType().GetField("_floors", BindingFlags.NonPublic)?.SetValue(b, Random.Range(3, 30));
        }
        
        GameObject man = new GameObject("Manager");
        var a = man.AddComponent<BuildingManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
