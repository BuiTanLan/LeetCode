using System.Text.Json;

int[] TwoSum(int[] nums, int target)
{
    var dic = new Dictionary<int, int>();

    for (int i = 0; i < nums.Length; i++)
    {
        if (dic.ContainsKey(nums[i]))
            return new int[] { dic[nums[i]], i };
        else
            dic[target - nums[i]] = i;
    }

    return Array.Empty<int>();
}

// call function
var nums = new int[] { 8, 4, 5, 3, 12, 4, 4, 5, 7, 6, 5 };
var target = 110;
Console.WriteLine(JsonSerializer.Serialize(TwoSum(nums, target)));
Console.ReadKey();