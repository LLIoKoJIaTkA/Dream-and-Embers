using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Transform heroPosition;
    public int CheckPointIndex;
    
    private void Start() 
    {
        heroPosition = GameObject.Find("Hero").transform;
        DataContainer.checkpointIndex = PlayerPrefs.GetInt("checkpointIDX");
        if (DataContainer.checkpointIndex == CheckPointIndex)
        {
            heroPosition.position = transform.position;
        }
    }

    private void Awake() 
    {
        heroPosition = GameObject.Find("Hero").transform;
        if (DataContainer.checkpointIndex == CheckPointIndex)
        {
            heroPosition.position = transform.position;
        }    
    }

    private void OnTriggerEnter2D(Collider2D other) 
    {
        if ((other.gameObject.name == "Hero") && (CheckPointIndex > DataContainer.checkpointIndex))
        {              
            DataContainer.checkpointIndex = CheckPointIndex;
            PlayerPrefs.SetInt("checkpointIDX", CheckPointIndex);
        }
    }
}
