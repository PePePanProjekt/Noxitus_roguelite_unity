
using UnityEngine;

public class DetectPlayer : MonoBehaviour
{
    
    Transform playerPos;
    
    private float dis;
    [SerializeField] private float dis2;
    
    void Awake()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;
        Init();
    }

    protected virtual void Init()
    {
        
    }

    
    void Update()
    {
        var position = transform.position;
        dis = Vector3.Distance(position, playerPos.position);

        if (dis < dis2)
        {
            PlayerDetected();
        }
        else
        {
            PlayerAway();
        }
    }

    public float GetDistance()
    {
        return dis;
    }

    protected virtual void PlayerDetected()
    {
        
    }
    
    protected virtual void PlayerAway()
    {
        
    }
}
