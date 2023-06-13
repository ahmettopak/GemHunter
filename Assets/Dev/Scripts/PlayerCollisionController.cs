using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionController : MonoBehaviour {

    private Stack<GameObject> collectedObjects = new Stack<GameObject>();
    [SerializeField] GameObject backPack;
    List<GameObject> collectedObjectsList;

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
       
           // Debug.Log(collectedObjects.Count + " " + collectedObjects.Peek().transform.position.y);
        }

        else if (touchedObject.CompareTag("SellPoint")) {
            StartCoroutine(SellObjectsCoroutine());
            
        }

      

    }

    private IEnumerator SellObjectsCoroutine() {
        while (collectedObjects.Count > 0) {
            // Nesneyi yok et
            GameObject objectToDestroy = collectedObjects.Pop();

            Destroy(objectToDestroy);
            Debug.Log("Sildi");
            // Belirli bir süre beklet
            yield return new WaitForSeconds(0.1f);
        }

        
    }
    private void SellObject(GameObject sellObject) {
       
    }
}
