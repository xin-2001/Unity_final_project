using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class TriggerVolume : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out carController player))
        {
            OnEnter.Invoke(player.gameObject);
            Debug.Log(other.gameObject);
        }
    }
}
