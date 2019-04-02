using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundTeleport : MonoBehaviour
{

    public bool isHorizontal; // prawda jesli jest to sciana lewa lub prawa
    public float margin = 2f;

    private void OnTriggerEnter2D(Collider2D collision)
    { 
        //sprawdzanei czy to Player
        if (collision.CompareTag("Player"))
        {
            PlayerController player = FindObjectOfType<PlayerController>(); //pobieranie komponentu playera
            //sprawdza przez ktorą czescia ekranu miał stycznosć nasz player (isHorizontal true jesli byłą to lewa lub prawa krawędź)
            //nastepnie wy konuje polecenia zmiany pozycji gracza na inne miejsce
            //TODO odejmowanie pkt za skorzystanie z teleportu
            if (isHorizontal)
            {
                //TODO particle teleportacji

                if (player.transform.position.x > 0)
                    player.transform.position = new Vector3(-(player.transform.position.x - margin), player.transform.position.y, player.transform.position.z);
                else if (player.transform.position.x < 0)
                    player.transform.position = new Vector3(-(player.transform.position.x + margin), player.transform.position.y, player.transform.position.z);
            }
            else if (!isHorizontal)
            {
                //TODO particle teleportacji

                if (player.transform.position.y > 0)
                    player.transform.position = new Vector3(player.transform.position.x, -(player.transform.position.y - margin), player.transform.position.z);
                else
                    player.transform.position = new Vector3(player.transform.position.x, -(player.transform.position.y + margin), player.transform.position.z);
            }

            //dezorientuje wszystkich przeciwników sprawia że na krótki czas gubią naszego gracza jako target do ataku
            EnemyAI[] enemies = FindObjectsOfType<EnemyAI>();
            foreach (EnemyAI enemy in enemies)
            {
                enemy.disorientation = true;
            }
        }
    }
}
