using System;
using System.Collections.Generic;

public class CurrentStateData
{
    private static StateData _currentStateData;
    private static GameData _currentGameData;

    public static void LoadStateData()
    {
        _currentStateData = DataSaver.LoadData<StateData>("current_state") ?? new StateData();
        _currentStateData.saveEntries ??= new SaveEntry[3];
        _currentStateData.scoreEntries ??= new List<ScoreEntry>();

        _currentGameData.playerName = _currentStateData.playerName;
        _currentGameData.scene = "level_01";
        _currentGameData.coin = 0;
        _currentGameData.playTime = 0;
        _currentGameData.currentWeapon = 0;
        _currentGameData.pets = new List<int>();
        _currentGameData.weapons = new []{true, true, true, true};
        _currentGameData.dmgMultiplier = 1f;
    }

    public static void SaveStateData()
    {
        DataSaver.SaveData(_currentStateData, "current_state");
    }

    public static string GetGlobalPlayerName()
    {
        return _currentStateData.playerName;
    }

    public static void ChangeGlobalPlayerName(string name)
    {
        _currentStateData.playerName = name;
    }

    public static int GetVolume()
    {
        return _currentStateData.volume;
    }

    public static void ChangeVolume(int volumeDiff)
    {
        _currentStateData.volume += volumeDiff;
        _currentStateData.volume = Math.Min(Math.Max(_currentStateData.volume, 0), 100);
    }

    public static SaveEntry[] GetSaveEntries()
    {
        return _currentStateData.saveEntries;
    }

    public static List<ScoreEntry> GetScoreEntries()
    {
        _currentStateData.scoreEntries.Sort((s1, s2) => s1.playTime.CompareTo(s2.playTime));
        return _currentStateData.scoreEntries;
    }

    public static bool LoadGameData(int index)
    {
        var loadedSaveEntry = _currentStateData.saveEntries[index];
        
        _currentGameData.playerName = loadedSaveEntry.playerName;
        _currentGameData.scene = loadedSaveEntry.scene;
        _currentGameData.coin = loadedSaveEntry.coin;
        _currentGameData.playTime = loadedSaveEntry.playTime;
        _currentGameData.currentWeapon = loadedSaveEntry.currentWeapon;
        _currentGameData.weapons = loadedSaveEntry.weapons;
        _currentGameData.pets = loadedSaveEntry.pets;
        // _currentGameData.dmgMultiplier = 1f;

        return true;
    }

    public static void SaveGameData(string saveName, int index)
    {
        var saveEntry = new SaveEntry
        {
            saveName = saveName,
            saveDateTime = DateTime.Now,
            playerName = _currentGameData.playerName,
            playTime = _currentGameData.playTime,
            coin = _currentGameData.coin,
            scene = _currentGameData.scene,
            currentWeapon = _currentGameData.currentWeapon,
            weapons = _currentGameData.weapons,
            pets = _currentGameData.pets
        };
        
        _currentStateData.saveEntries[index] = saveEntry;
        SaveStateData();
    }

    public static string GetCurrentPlayerName()
    {
        return _currentGameData.playerName;
    }

    public static int GetCurrentCoin()
    {
        return _currentGameData.coin;
    }

    public static int SetCurrentCoin(int coin)
    {
        return _currentGameData.coin = coin;
    }
    
    public static void AddCoin(int coin)
    {
        _currentGameData.coin += coin;
    }

    public static bool SubtractCoin(int coin)
    {
        if (_currentGameData.coin < coin) 
            return false;

        _currentGameData.coin -= coin;
        return true;
    }

    public static float GetCurrentPlayTime()
    {
        return _currentGameData.playTime;
    }

    public static void AddPlayTime(float delta)
    {
        _currentGameData.playTime += delta;
    }

    public static string GetCurrentScene()
    {
        return _currentGameData.scene;
    }

    public static void ChangeScene(string scene)
    {
        _currentGameData.scene = scene;
    }

    public static int GetCurrentPet()
    {
        if (_currentGameData.pets.Count > 0)
        {
            return _currentGameData.pets[0];
        }
        else
        {
            return -1;
        }
    }

    public static void RemoveCurrentPet()
    {
        if (_currentGameData.pets.Count > 0)
        {
            _currentGameData.pets.RemoveAt(0);
        }
        else
        {
            throw new Exception("How can you remove pet that is nowhere to be found??");
        }
    }

    public static void AddPet(int pet)
    {
        _currentGameData.pets.Add(pet);
    }

    public static int GetPetsLength()
    {
        return _currentGameData.pets.Count;
    }

    public static bool[] GetWeapons()
    {
        return _currentGameData.weapons;
    }

    public static int GetCurrentWeapon()
    {
        return _currentGameData.currentWeapon;
    }

    public static void SetCurrentWeapon(int weapon)
    {
        if (!_currentGameData.weapons[weapon]) return;
        _currentGameData.currentWeapon = weapon;
    }

    public static void AddWeapon(int weapon)
    {
        _currentGameData.weapons[weapon] = true;
    }

    public static float GetMultiplier()
    {
        return _currentGameData.dmgMultiplier;
    }

    public static void SetMultiplier(float multiplier)
    {
        _currentGameData.dmgMultiplier = multiplier;
    }
}