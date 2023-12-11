﻿using WECCL.Saves;

namespace WECCL.Utils;

public class CharacterUtils
{
    
    public static void SaveAsBackup(int id)
    {
        NonSavedData.DeletedCharacters.Add(Characters.c[id]);
    }
    
    public static void DeleteCharacter(int id)
    {
        SaveAsBackup(id);
        
        if (Characters.wrestler == id)
        {
            Characters.wrestler = 1;
        }
        else if (Characters.wrestler > id)
        {
            Characters.wrestler--;
        }
        
        if (Characters.booker == id)
        {
            Characters.booker = 1;
        }
        else if (Characters.booker > id)
        {
            Characters.booker--;
        }
        
        if (Progress.missionClient == id)
        {
            Progress.missionClient = 1;
        }
        else if (Progress.missionClient > id)
        {
            Progress.missionClient--;
        }
        
        if (Progress.missionTarget == id)
        {
            Progress.missionTarget = 1;
        }
        else if (Progress.missionTarget > id)
        {
            Progress.missionTarget--;
        }
        
        for (int i = 1; i < Progress.opponent.Length; i++)
        {
            if (Progress.opponent[i] == id)
            {
                Progress.opponent[i] = 1;
            }
            else if (Progress.opponent[i] > id)
            {
                Progress.opponent[i]--;
            }
        }
        
        foreach (var card in Progress.card)
        {
            if (card == null)
            {
                continue;
            }
            foreach (var segment in card.segment)
            {
                if (segment == null)
                {
                    continue;
                }
                if (segment.leftChar == id)
                {
                    segment.leftChar = 1;
                }
                else if (segment.leftChar > id)
                {
                    segment.leftChar--;
                }
                if (segment.rightChar == id)
                {
                    segment.rightChar = 1;
                }
                else if (segment.rightChar > id)
                {
                    segment.rightChar--;
                }
                if (segment.winner == id)
                {
                    segment.winner = 1;
                }
                else if (segment.winner > id)
                {
                    segment.winner--;
                }
            }
        }
        
        for (int i = 1; i < Progress.hiChar.Length; i++)
        {
            if (Progress.hiChar[i] == id)
            {
                Progress.hiChar[i] = 1;
            }
            else if (Progress.hiChar[i] > id)
            {
                Progress.hiChar[i]--;
            }
        }
        
        for (int i = 1; i < MappedItems.stock.Length; i++)
        {
            if (MappedItems.stock[i] == null)
            {
                continue;
            }
            if (MappedItems.stock[i].owner == id)
            {
                MappedItems.stock[i].owner = 1;
            }
            else if (MappedItems.stock[i].owner > id)
            {
                MappedItems.stock[i].owner--;
            }
        }
        
        for (int i = 1; i < MappedWeapons.stock.Length; i++)
        {
            if (MappedWeapons.stock[i] == null)
            {
                continue;
            }
            if (MappedWeapons.stock[i].owner == id)
            {
                MappedWeapons.stock[i].owner = 1;
            }
            else if (MappedWeapons.stock[i].owner > id)
            {
                MappedWeapons.stock[i].owner--;
            }
        }
        
        foreach (var character in Characters.c)
        {
            if (character == null)
            {
                continue;
            }
            for (int i = 1; i < character.relationship.Length; i++)
            {
                if (character.relationship[i] == id)
                {
                    character.relationship[i] = 1;
                }
                else if (character.relationship[i] > id)
                {
                    character.relationship[i]--;
                }
            }
            if (character.grudge == id)
            {
                character.grudge = 1;
            }
            else if (character.grudge > id)
            {
                character.grudge--;
            }
        }
        
        foreach (MappedRoster fedData in Characters.fedData)
        {
            if (fedData == null)
            {
                continue;
            }
            if (fedData.owner == id)
            {
                fedData.owner = fedData.size > 0 ? fedData.RandomCharacter() : 1;
            }
            else if (fedData.owner > id)
            {
                fedData.owner--;
            }
            if (fedData.booker == id)
            {
                fedData.booker = fedData.size > 0 ? fedData.RandomCharacter() : 1;
            }
            else if (fedData.booker > id)
            {
                fedData.booker--;
            }
            for (int i = 1; i < fedData.roster.Length; i++)
            {
                if (fedData.roster[i] > id)
                {
                    fedData.roster[i]--;
                }
            }
            for (int i = 1; i < fedData.champ.GetLength(0); i++)
            {
                for (int j = 1; j < fedData.champ.GetLength(1); j++)
                {
                    if (fedData.champ[i, j] == id)
                    {
                        fedData.champ[i, j] = fedData.size > 0 ? fedData.FindNewChampion(i) : 1;
                    }
                    else if (fedData.champ[i, j] > id)
                    {
                        fedData.champ[i, j]--;
                    }
                }
            }
        }
        
        ((MappedRoster)Characters.fedData[Characters.c[id].fed]).RemoveCharacter(id);
                
        for (int i = id; i < Characters.c.Length - 1; i++)
        {
            Characters.c[i] = Characters.c[i + 1];
            Characters.c[i].id = i;
        }
        
        for (int i = id; i < Progress.charUnlock.Length - 1; i++)
        {
            Progress.charUnlock[i] = Progress.charUnlock[i + 1];
        }
        
        Characters.no_chars--;
        Array.Resize(ref Characters.c, Characters.no_chars + 1);
        Array.Resize(ref Progress.charUnlock, Characters.no_chars + 1);
        Array.Resize(ref GLPGLJAJJOP.APPDIBENDAH.savedChars, Characters.no_chars + 1);
        Array.Resize(ref GLPGLJAJJOP.APPDIBENDAH.charUnlock, Characters.no_chars + 1);
    }

    public static void CreateRandomCharacter()
    {
        Characters.no_chars++;
        Array.Resize(ref Characters.c, Characters.no_chars + 1);
        Array.Resize(ref Progress.charUnlock, Characters.no_chars + 1);
        Array.Resize(ref GLPGLJAJJOP.APPDIBENDAH.savedChars, Characters.no_chars + 1);
        Array.Resize(ref GLPGLJAJJOP.APPDIBENDAH.charUnlock, Characters.no_chars + 1);
        Progress.charUnlock[Characters.no_chars] = 1;
        Characters.c[Characters.no_chars] = new Character();
        ((MappedCharacter) Characters.c[Characters.no_chars]).Generate(Characters.no_chars);
        ((MappedCharacter)Characters.c[Characters.no_chars]).fed = -1;
        if (Characters.fedData[9].size + 1 == Characters.fedData[9].roster.Length)
        {
            Array.Resize(ref Characters.fedData[9].roster, Characters.fedData[9].roster.Length + 1);
            if (Characters.fedData[9].roster.Length > Characters.fedLimit)
            {
                Characters.fedLimit++;
            }
        }
        ((MappedCharacter) Characters.c[Characters.no_chars]).Trade(9);
    }
}