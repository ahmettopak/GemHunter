using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StackingManager : MonoBehaviour
{
    private Vector3 _firstCubePos;
    private Vector3 _currentCubePos;

    List<GameObject> _cubeList = new List<GameObject>();
    private int _cubeListIndexCounter = 0;

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("GreenGem")) {
            Debug.Log("GreenGem");
            _cubeList.Add(collision.gameObject);
            if (_cubeList.Count == 1) {
                _firstCubePos = GetComponent<MeshRenderer>().bounds.max;
                _currentCubePos = new Vector3(collision.transform.position.x, _firstCubePos.y, collision.transform.position.z);
                collision.gameObject.transform.position = _currentCubePos;
                
                _currentCubePos = new Vector3(collision.transform.position.x, transform.position.y + collision.gameObject.transform.position.y, collision.transform.position.z);
                collision.gameObject.GetComponent<Gem>().UpdateCubePosition(transform, true);
            }
            else if (_cubeList.Count > 1) {
                collision.gameObject.transform.position = _currentCubePos;
                _currentCubePos = new Vector3(collision.transform.position.x, collision.gameObject.transform.position.y + 0.3f, collision.transform.position.z);
                collision.gameObject.GetComponent<Gem>().UpdateCubePosition(_cubeList[_cubeListIndexCounter].transform, true);
                _cubeListIndexCounter++;
            }
        }
    }
}
