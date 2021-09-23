using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour {
    
    public float timeStampBuildRoadBridge;
    public string grabColor = "green";
    public List<GameObject> bridgeRoads;
    public List<GameObject> roads;
    public int cursorOfBridgeRoads = 0;
    public float speed = 1f;
    Rigidbody rb;
    public int countRoads = 0;
    public GameObject boost;
    void Start() {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate() {
        //print(rb.velocity);
         if(!Input.anyKey){
            GetComponent<Animator>().Play("idle");
         }
        if (Input.GetKey(KeyCode.W) ){
            boost.SetActive(true);

            // transform.Translate(Vector3.forward * Time.deltaTime * speed);
            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, 3f);
            GetComponent<Animator>().Play("run");
            transform.rotation = Quaternion.Euler(0,0,0);
            Camera.main.transform.Translate(Vector3.forward * Time.deltaTime * speed, Space.World);
        } else if(Input.GetKeyUp(KeyCode.W)){
            boost.SetActive(false);

           // rb.velocity=Vector3.zero;
        }
        if (Input.GetKey(KeyCode.S) ){
            boost.SetActive(true);

            rb.velocity = new Vector3(rb.velocity.x, rb.velocity.y, -3f);
            GetComponent<Animator>().Play("run");
            transform.rotation=Quaternion.Euler(0,180,0);
            Camera.main.transform.Translate(Vector3.back * Time.deltaTime * speed, Space.World);
        } else if(Input.GetKeyUp(KeyCode.S)){
            boost.SetActive(false);

           // rb.velocity=Vector3.zero;
        }
        if (Input.GetKey(KeyCode.A) ){
            boost.SetActive(true);

            rb.velocity = new Vector3(-3f, rb.velocity.y, rb.velocity.z);
            GetComponent<Animator>().Play("run");
            transform.rotation = Quaternion.Euler(0,-90,0);
            Camera.main.transform.Translate(Vector3.left * Time.deltaTime * speed, Space.World);
        } else if(Input.GetKeyUp(KeyCode.A)){
            boost.SetActive(false);

           // rb.velocity=Vector3.zero;
        }
        if (Input.GetKey(KeyCode.D) ){
            boost.SetActive(true);

            rb.velocity = new Vector3(3f, rb.velocity.y, rb.velocity.z);
            GetComponent<Animator>().Play("run");
            transform.rotation = Quaternion.Euler(0,90,0);
            Camera.main.transform.Translate(Vector3.right * Time.deltaTime * speed, Space.World);
            //gameObject.transform.Rotate(new Vector3(0,90,0));
        }else if(Input.GetKeyUp(KeyCode.D)){
            boost.SetActive(false);

          //  rb.velocity=Vector3.zero;
        }
    }

    void OnCollisionEnter(Collision other){
        if(other.gameObject.tag == "Road" && !other.gameObject.GetComponent<RoadLogic>().grab && grabColor.Contains(other.gameObject.GetComponent<RoadLogic>().grabColor)){

            //помещаем дорожку за спину игрока
            other.gameObject.GetComponent<BoxCollider>().isTrigger = true;
            //other.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            roads.Add(other.gameObject);
            countRoads++;
            other.gameObject.GetComponent<RoadLogic>().grab = true;
            other.gameObject.transform.parent = gameObject.transform;

            other.gameObject.GetComponent<AudioSource>().Play();

            /*
            if(countRoads >= 2){
                other.gameObject.GetComponent<RoadLogic>().player = roads[countRoads - 1];
            } else if(countRoads <= 1){
                other.gameObject.GetComponent<RoadLogic>().player = gameObject.transform.GetChild(2).gameObject;
            }
            */

            other.gameObject.GetComponent<RoadLogic>().cursor = countRoads - 1;
            if(other.gameObject.GetComponent<RoadLogic>().cursor >= 1){
                other.gameObject.GetComponent<RoadLogic>().player = roads[countRoads - 2];
            } else if(other.gameObject.GetComponent<RoadLogic>().cursor <= 0){
                //other.gameObject.GetComponent<RoadLogic>().player = gameObject.transform.GetChild(2).gameObject;
            }

        } else if(other.gameObject.tag.Contains("BridgeRoad")){
            if(countRoads >= 1 && other.gameObject.GetComponent<BridgeRoad>().lastRoad){
                //делаем новую дорожку на мосту

                Destroy(other.gameObject.GetComponent<Rigidbody>());

                timeStampBuildRoadBridge = Time.timeSinceLevelLoad;
                
                other.gameObject.GetComponent<AudioSource>().Play();

                countRoads--;
                Destroy(roads[countRoads]);
                roads.RemoveAt(countRoads);
                
                foreach(GameObject bridgeRoad in bridgeRoads){
                    bridgeRoad.GetComponent<BridgeRoad>().lastRoad = false;
                }
                cursorOfBridgeRoads++;
                bridgeRoads[cursorOfBridgeRoads].SetActive(true);
                bridgeRoads[cursorOfBridgeRoads].GetComponent<BridgeRoad>().lastRoad = true;
                
            }
            
        }
    }

}
