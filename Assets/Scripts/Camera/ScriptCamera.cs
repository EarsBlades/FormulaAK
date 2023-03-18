using UnityEngine;

public class ScriptCamera : MonoBehaviour
{
    [SerializeField] private Transform _car;
    private Vector3 _camera = new Vector3(0f, 4.5f, -11);
    private float _speed = 10f;

    private void FixedUpdate()
    {
        var targetPosition = _car.TransformPoint(_camera);
        transform.position = Vector3.Lerp(transform.position, targetPosition, _speed * Time.deltaTime);

        var direction = _car.position - transform.position;
        var rotation = Quaternion.LookRotation(direction, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, rotation, _speed * Time.deltaTime);
    }
}
