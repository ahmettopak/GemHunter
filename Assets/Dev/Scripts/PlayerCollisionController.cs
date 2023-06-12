using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour {

    private Stack<GameObject> collectedObjects = new Stack<GameObject>();
    [SerializeField] GameObject backPack;

    private void Start() {
        collectedObjects.Clear();
    }

    void OnCollisionEnter(Collision collision) {

        GameObject touchedObject = collision.gameObject;

        if (touchedObject.CompareTag("Gem") && !collectedObjects.Contains(touchedObject)) {

            collectedObjects.Push(touchedObject);

            touchedObject.transform.position = new Vector3(0, 0, 0);
            touchedObject.transform.SetParent(backPack.transform, true);
            touchedObject.transform.position = new Vector3(backPack.transform.position.x,collectedObjects.Count, backPack.transform.position.z);
       
            Debug.Log(collectedObjects.Count + " " + collectedObjects.Peek().transform.position.y);
        }

    }
}
