using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using Sirenix.OdinInspector;

public class MakeMoney : MonoBehaviour
{
    [Title("Lottery Results")]
    [TableList(AlwaysExpanded = true)]
    public List<LotteryData> lotteryResults = new List<LotteryData>();

    private Dictionary<int, int> frequency = new Dictionary<int, int>();
    private HashSet<int> recentNumbers = new HashSet<int>();

    [Button("🔥 Tạo 20 bộ số tối ưu")]
    private void GenerateOptimizedSets()
    {
        BuildFrequencyMap();

        // Sắp xếp theo tần suất từ cao xuống thấp
        var sorted = frequency.OrderByDescending(kvp => kvp.Value).Select(kvp => kvp.Key).ToList();

        // Chia nhóm tần suất
        var high = sorted.Take(15).ToList();
        var medium = sorted.Skip(15).Take(20).ToList();
        var low = sorted.Skip(35).ToList();

        // Lấy các số vừa xuất hiện gần nhất (3 kỳ)
        recentNumbers = new HashSet<int>(
            lotteryResults
            .TakeLast(3)
            .SelectMany(r => r.GetNumbers())
        );

        List<List<int>> allPredictions = new List<List<int>>();

        for (int i = 0; i < 20; i++)
        {
            var set = new HashSet<int>();

            set.UnionWith(PickRandomDistinct(high, 2, set));
            set.UnionWith(PickRandomDistinct(medium, 2, set));
            set.UnionWith(PickRandomDistinct(low, 2, set));

            var final = set.OrderBy(n => n).ToList();
            allPredictions.Add(final);
        }

        Debug.Log("<color=green>📈 Dự đoán 20 bộ số tối ưu:</color>");
        for (int i = 0; i < allPredictions.Count; i++)
        {
            Debug.Log($"i" + "========/ " + string.Join(", ", allPredictions[i]));
        }
    }

    private List<int> PickRandomDistinct(List<int> source, int count, HashSet<int> exclude)
    {
        var result = new List<int>();
        var filtered = source.Where(n => !exclude.Contains(n) && !recentNumbers.Contains(n)).ToList();

        while (result.Count < count && filtered.Count > 0)
        {
            int n = filtered[Random.Range(0, filtered.Count)];
            result.Add(n);
            exclude.Add(n);
            filtered.Remove(n);
        }

        // Nếu chưa đủ, bổ sung bằng số đã loại recent nhưng chưa trùng
        if (result.Count < count)
        {
            var backup = source.Where(n => !exclude.Contains(n)).ToList();
            while (result.Count < count && backup.Count > 0)
            {
                int n = backup[Random.Range(0, backup.Count)];
                result.Add(n);
                exclude.Add(n);
                backup.Remove(n);
            }
        }

        return result;
    }

    private void BuildFrequencyMap()
    {
        frequency = new Dictionary<int, int>();
        for (int i = 1; i <= 55; i++) frequency[i] = 0;

        foreach (var entry in lotteryResults)
        {
            foreach (var number in entry.GetNumbers())
            {
                if (frequency.ContainsKey(number))
                    frequency[number]++;
            }
        }
    }

    [Button("Sum String")]
    private void HandleSunString()
    {
        var temp = "";
        foreach (var item in lotteryResults)
        {
            temp += item.DataStr + "\n";
        }
        Debug.LogError("temp_" + temp);
    }

    [System.Serializable]
    public class LotteryData
    {
        [HorizontalGroup("Split"), LabelWidth(60)]
        public string DataStr;

        public List<int> GetNumbers()
        {
            var parts = DataStr.Split(new char[] { ' ', ',', '-', '.' }, System.StringSplitOptions.RemoveEmptyEntries);
            return parts
                .Select(p =>
                {
                    int.TryParse(p, out int n);
                    return n;
                })
                .Where(n => n >= 1 && n <= 55)
                .ToList();
        }
    }
}
