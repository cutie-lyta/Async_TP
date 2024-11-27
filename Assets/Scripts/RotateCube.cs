using System.Collections;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class RotateCube : MonoBehaviour
{
    private CancellationTokenSource _token;

    public void StopSpin()
    {
        _token.Cancel();
    }

    public void Spin()
    {
        if(_token != null) _token.Cancel();
        
        _token = new();
        SpinAsync().Forget();
    }
    
    public async UniTaskVoid SpinAsync()
    {
        float _timer = 0;
        float baseRotation = transform.rotation.eulerAngles.y;
        
        while (_timer < 5.0f)
        {
            _timer += Time.fixedDeltaTime;
            transform.rotation = Quaternion.Euler(0, baseRotation + (360 * _timer), 0);
            await UniTask.WaitForFixedUpdate(_token.Token);
        }
    }
    
}
