using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Test_TriggerVolume : MonoBehaviour
{
    public UnityEvent<GameObject> OnEnter;

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Test_CharacterMovement player))
        {
            OnEnter.Invoke(player.gameObject);
        }
    }
}
