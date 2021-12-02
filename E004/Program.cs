double FindMedianSortedArrays(int[] nums1, int[] nums2)
{
    var m = nums1.Length + nums2.Length;
    if (m % 2 == 1)
        return FindKth(nums1, 0, nums2, 0, (m + 1) / 2);
    return (FindKth(nums1, 0, nums2, 0, (m + 1) / 2) + FindKth(nums1, 0, nums2, 0, (m + 1) / 2 + 1)) / 2;
}

double FindKth(int[] nums1, int startIndex1, int[] nums2, int startIndex2, int k)
{
    while (true)
    {
        var nums1Left = nums1.Length - startIndex1;
        var nums2Left = nums2.Length - startIndex2;

        if (nums1Left < nums2Left)
        {
            var nums3 = nums1;
            var startIndex3 = startIndex1;
            nums1 = nums2;
            startIndex1 = startIndex2;
            nums2 = nums3;
            startIndex2 = startIndex3;
            continue;
        }

        if (nums2.Length <= startIndex2)
        {
            return nums1[startIndex1 + k - 1];
        }

        if (k == 1)
        {
            return nums1[startIndex1] < nums2[startIndex2] ? nums1[startIndex1] : nums2[startIndex2];
        }

        var index1 = k / 2 < nums1Left ? k / 2 : nums1Left;
        var index2 = k - index1 < nums2Left ? k - index1 : nums2Left;
        if (nums1[index1 + startIndex1 - 1] > nums2[index2 + startIndex2 - 1])
        {
            startIndex2 = index2 + startIndex2;
            k -= index2;
            continue;
        }

        if (nums1[index1 + startIndex1 - 1] < nums2[index2 + startIndex2 - 1])
        {
            startIndex1 = index1 + startIndex1;
            k -= index1;
            continue;
        }

        if (index1 + index2 == k) return nums1[index1 + startIndex1 - 1];
        startIndex1 = index1 + startIndex1;
        startIndex2 = index2 + startIndex2;
        k = k - index1 - index2;
    }
}