using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    [Header("Levels")]
    [SerializeField] private GameObject[] _levels;
    [SerializeField] private float _stayTime = 15f;

    // private
    private bool _isSpawmed;
    private float _elapsedTime;

    public void SpawnLevel()
    {
        if (_levels == null) return;

        int randomIndex = Random.Range(0, _levels.Length);
        GameObject level = Instantiate(_levels[randomIndex], transform.position, transform.rotation) as GameObject;

        level.name = level.name.Replace("(Clone)", "").Trim();

        _isSpawmed = true;
    }

    private void Update()
    {
        if(!_isSpawmed) return;

        _elapsedTime += Time.deltaTime;

        if(_elapsedTime >= _stayTime)
        {
            _elapsedTime = 0;
            _isSpawmed = false;
            Destroy(transform.parent.parent.gameObject);
        }
    }
}
