using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadLogic : MonoBehaviour {

    public GameObject player;
    public bool grab = false;
    public string grabColor;
    public int cursor;

    void Start() {
        
    }

    void FixedUpdate() {
        /*
        if(grab){
            if(player.transform.parent.gameObject.GetComponent<GameLogic>().countRoads >= 2){
                if (Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, new Vector3(player.transform.parent.gameObject.GetComponent<GameLogic>().roads[player.transform.parent.gameObject.GetComponent<GameLogic>().countRoads - 1].GetComponent<Rigidbody>().position.x, player.transform.parent.gameObject.GetComponent<GameLogic>().roads[player.transform.parent.gameObject.GetComponent<GameLogic>().countRoads - 1].GetComponent<Rigidbody>().position.y + 5f, player.transform.parent.gameObject.GetComponent<GameLogic>().roads[player.transform.parent.gameObject.GetComponent<GameLogic>().countRoads - 1].GetComponent<Rigidbody>().position.z)) > 0.2f) {
                    gameObject.transform.position = Vector3.MoveTowards (gameObject.GetComponent<Rigidbody>().position, player.transform.parent.gameObject.GetComponent<Rigidbody>().position, 15f * Time.deltaTime);
                } else if(Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.transform.parent.gameObject.GetComponent<Rigidbody>().position) <= 0.2f){
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            } else if(player.transform.parent.gameObject.GetComponent<GameLogic>().countRoads <= 1){
                if (Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.transform.parent.gameObject.GetComponent<Rigidbody>().position) > 0.2f) {
                    gameObject.transform.position = Vector3.MoveTowards (gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position, 15f * Time.deltaTime);
                } else if(Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position) <= 0.2f){
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            }
        }
        */
        
        if(grab){
            if(cursor >= 1){
                if (Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position + new Vector3(0f, 0.3f, 0f)) > 0.2f) {
                    gameObject.transform.position = Vector3.MoveTowards (gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position + new Vector3(0f, 0.3f, 0f), 15f * Time.deltaTime);
                } else if(Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position) <= 0.2f){
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            } else if(cursor <= 0){
                if (Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.transform.parent.gameObject.GetComponent<Rigidbody>().position) > 0.2f) {
                    gameObject.transform.position = Vector3.MoveTowards (gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position, 15f * Time.deltaTime);
                } else if(Vector3.Distance(gameObject.GetComponent<Rigidbody>().position, player.GetComponent<Rigidbody>().position) <= 0.2f){
                    gameObject.GetComponent<BoxCollider>().isTrigger = false;
                }
            }
        }
           

    }
}
