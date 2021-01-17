using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    [SerializeField] List<Transform> waypoints;

    int points = 5;

    [SerializeField] WaveConfig waveConfig;
    int waypointIndex = 0;

    [SerializeField] AudioClip playerPointSound;
    [SerializeField] [Range(0, 1)] float playerPointSoundVolume = 0.75f;

    private void Start()
    {
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].transform.position;
    }

    private void Update()
    {
        ObstacleMove();
    }

    private void ObstacleMove()
    {
        if(waypointIndex <= waypoints.Count - 1)
        {
            var targetPosition = waypoints[waypointIndex].transform.position;
            targetPosition.z = 0f;
            var obstacleMovement = waveConfig.GetObstacleMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        else
        {
            FindObjectOfType<GameSession>().AddToScore(points);
            Destroy(gameObject);
            AudioSource.PlayClipAtPoint(playerPointSound, Camera.main.transform.position, playerPointSoundVolume);
        }
    }
    public void SetWaveConfig(WaveConfig waveConfigToSet)
    {
        waveConfig = waveConfigToSet;
    }
}
