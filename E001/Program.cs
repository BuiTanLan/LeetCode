using System.Text.Json;

int[] TwoSum(int[] nums, int target)
{
    var dic = new Dictionary<int, int>();

    for (var i = 0; i < nums.Length; i++)
    {
        if (dic.ContainsKey(nums[i]))
            return new[] { dic[nums[i]], i };
        dic[target - nums[i]] = i;
    }

    return Array.Empty<int>();
}

// call function
var nums = new[] { 8, 4, 5, 3, 12, 4, 4, 5, 7, 6, 5 };
const int target = 110;
Console.WriteLine(JsonSerializer.Serialize(TwoSum(nums, target)));
Console.ReadKey();