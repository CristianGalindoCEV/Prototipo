using UnityEngine;

public class Patrullero : MonoBehaviour
{
    public SpacePoint[] puntos;
    int currentPoint = 0;

    [SerializeField] float speed;

    [SerializeField] float rangeDistanceMin;
    [SerializeField] float rangeDistanceMax;
    float rangeDistance = 6;
    [SerializeField] Transform player;
    [SerializeField] float speedChase;

 
    

    private void Awake()
    {
        rangeDistance = rangeDistanceMin;
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }
    
   

    void Update()
    {
        if (puntos.Length < 2) { Debug.LogError("Pon los puntos del recorrido"); return;  }

        //Miramos si hemos llegado al punto actual
        if(Vector3.Distance(transform.position, puntos[currentPoint].transform.position)< 0.2f){
            currentPoint++;
            currentPoint %= puntos.Length;
        }

        //Detecta Player
        
        if (Mathf.Abs(Vector3.Distance(player.position, transform.position)) < rangeDistance)
        {
            
            rangeDistance = rangeDistanceMax;
            
            transform.position = Vector3.MoveTowards(transform.position, player.position, Time.deltaTime * speedChase);
        }
        
        
        
        

        //Patrulla siguiente punto
        else
        {
            rangeDistance = rangeDistanceMin;
            transform.position = Vector3.MoveTowards(transform.position, puntos[currentPoint].transform.position, Time.deltaTime * speed);
            
        }
        


    }

}

