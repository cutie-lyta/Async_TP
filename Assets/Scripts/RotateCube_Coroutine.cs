using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCube_Coroutine : MonoBehaviour
{
    private Coroutine _currentlyRunningCoroutine;

    public void StopSpin()
    {
        if(_currentlyRunningCoroutine != null) StopCoroutine(_currentlyRunningCoroutine);
    }
    
    public void Spin()
    {
        if(_currentlyRunningCoroutine != null) StopCoroutine(_currentlyRunningCoroutine);
        _currentlyRunningCoroutine = StartCoroutine(SpinCoroutine());
    }
    
    public IEnumerator SpinCoroutine()
    {
        float _timer = 0;
        
        float baseRotation = transform.rotation.eulerAngles.y;
        
        while (_timer < 5.0f)
        {
            _timer += Time.fixedDeltaTime;
            transform.rotation = Quaternion.Euler(0, baseRotation + (360 * _timer), 0);
            yield return new WaitForFixedUpdate();
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
