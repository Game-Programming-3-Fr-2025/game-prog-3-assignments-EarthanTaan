using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

namespace PrototypeSix
{
    public class HunterScript : MonoBehaviour
    {
        private GameObject Player =  GameObject.Find("Player");
        public Vector2 Ppos;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Ppos = new Vector2(Player.transform.position.x, Player.transform.position.y);

        }

        // Update is called once per frame
        void Update()
        {
            transform.position = Vector2.MoveTowards(transform.position, Ppos, 5);

        }
    }
}