using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevelTrigger : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            SceneController.Instance.NextLevel();
        }
    }
}
