using UnityEngine;

public class MyFirstSript : MonoBehaviour
{
   public int coins = 100;

   public int level = 1;
   
   public float damage = 10.5f;

   public string name = "Sven";

   public bool imortal = false;

   public Vector3 velocity;

   private void Start()
   {
     Debug.Log("Привет");
   }

   private void Update()
   {
      transform.position += velocity;
   }

}

