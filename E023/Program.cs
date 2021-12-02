ListNode<int>? MergeKLists(ListNode<int>?[]? lists)
{
    if (lists is null || lists.Length == 0) return null;

    return MergeKHelper(lists, 0, lists.Length - 1);
}

ListNode<int>? MergeKHelper(IReadOnlyList<ListNode<int>?>? lists, int i, int j)
{
    if (i == j) return lists?[i];

    var mid = i + (j - i) / 2;
    var left = MergeKHelper(lists, i, mid);
    var right = MergeKHelper(lists, mid + 1, j);
    return MergeTwoLists(left, right);
}

ListNode<int>? MergeTwoLists(ListNode<int>? l1, ListNode<int>? l2)
{
    var head = new ListNode<int>(-1);
    var current = head;

    while (l1 is {} && l2 is {})
    {
        if (l1.Val <= l2.Val)
        {
            current.Next = l1;
            l1 = l1.Next;
        }
        else
        {
            current.Next = l2;
            l2 = l2.Next;
        }
        current = current.Next;
    }

    current.Next = l1 ?? l2;
    return head.Next;
}

internal class ListNode<T>
{
    public T? Val { get; set; }
    public ListNode<T>? Next { get; set; }

    public ListNode(T? val = default, ListNode<T>? next = null)
    {
        Val = val;
        Next = next;
    }
}

