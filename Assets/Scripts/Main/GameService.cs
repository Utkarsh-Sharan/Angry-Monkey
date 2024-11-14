using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ServiceLocator.Utilities;
using ServiceLocator.Player;
using ServiceLocator.Sound;
using ServiceLocator.UI;
using ServiceLocator.Map;
using ServiceLocator.Wave;
using ServiceLocator.Events;

public class GameService : GenericMonoSingleton<GameService>
{
    public PlayerService playerService { get; private set; }
    public SoundService soundService { get; private set; }
    public MapService mapService { get; private set; }
    public WaveService waveService { get; private set; }
    public EventService eventService { get; private set; }

    [SerializeField] private UIService uiService;
    public UIService UIService => uiService;

    //Player
    [SerializeField] private PlayerScriptableObject playerScriptableObject;

    //Sound
    [SerializeField] private SoundScriptableObject soundScriptableObject;
    [SerializeField] private AudioSource audioEffects;
    [SerializeField] private AudioSource backgroundMusic;

    //Map
    [SerializeField] private MapScriptableObject mapScriptableObject;

    //Wave
    [SerializeField] private WaveScriptableObject waveScriptableObject;

    private void Start()
    {
        eventService = new EventService();
        playerService = new PlayerService(playerScriptableObject);
        soundService = new SoundService(soundScriptableObject, audioEffects, backgroundMusic);
        mapService = new MapService(mapScriptableObject);
        waveService = new WaveService(waveScriptableObject);
    }

    private void Update()
    {
        playerService.Update();
    }
}
