using UnityEngine;

namespace Logic
{
    public class LookAtCamera : MonoBehaviour
    {
        private Camera _camera;
        
        private void Awake() => _camera = Camera.main;

        private void Update() =>
            transform.LookAt(transform.position + _camera.transform.rotation * Vector3.forward, _camera.transform.rotation * Vector3.up);
    }
}