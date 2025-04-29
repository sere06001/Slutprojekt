using System.IO;

namespace Slutprojekt;
public static class ScoreManager
{
    private static readonly string SavePath = "scores.dat";
    private static Dictionary<int, int> LevelHighScores = new();

    public static void Initialize()
    {
        LoadScores();
    }

    public static void SaveScore(int levelIndex, int score)
    {
        if (!LevelHighScores.ContainsKey(levelIndex) || score > LevelHighScores[levelIndex])
        {
            LevelHighScores[levelIndex] = score;
            SaveScores();
        }
    }

    public static int GetHighScore(int levelIndex)
    {
        return LevelHighScores.ContainsKey(levelIndex) ? LevelHighScores[levelIndex] : 0;
    }

    private static void SaveScores()
    {
        using (BinaryWriter writer = new BinaryWriter(File.Open(SavePath, FileMode.Create)))
        {
            writer.Write(LevelHighScores.Count);
            foreach (var pair in LevelHighScores)
            {
                writer.Write(pair.Key);
                writer.Write(pair.Value);
            }
        }
    }

    public static void LoadScores()
    {
        if (File.Exists(SavePath))
        {
            using (BinaryReader reader = new BinaryReader(File.Open(SavePath, FileMode.Open)))
            {
                try
                {
                    int count = reader.ReadInt32();
                    LevelHighScores.Clear();
                    for (int i = 0; i < count; i++)
                    {
                        int levelIndex = reader.ReadInt32();
                        int score = reader.ReadInt32();
                        LevelHighScores[levelIndex] = score;
                    }
                }
                catch (EndOfStreamException)
                {
                    LevelHighScores.Clear();
                }
            }
        }
    }
}
