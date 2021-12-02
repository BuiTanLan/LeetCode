
using System.Text.Json;

ListNode<int>? AddTwoNumbers(ListNode<int>? firstList, ListNode<int>? secondList)
{
    ListNode<int> head = new();
    var current = head;
    var carry = 0;
    while (firstList is { } || secondList is { })
    {
        var currentValFirst = firstList?.Val ?? 0;
        var currentValSecond = secondList?.Val ?? 0;
        var digit = carry + currentValFirst + currentValSecond;
        carry = digit / 10;
        current.Next = new ListNode<int>(digit % 10);
        current = current.Next;
        firstList = firstList?.Next;
        secondList = secondList?.Next;
    }
    if (carry > 0) 
    { 
        current.Next = new ListNode<int>(carry); 
    }
    return head.Next;
}

var l1 = new ListNode<int>(7)
{
    Next = new ListNode<int>(9)
    {
        Next = new ListNode<int>(3)
    }
};

var l2 = new ListNode<int>(5)
{
    Next = new ListNode<int>(5)
    {
        Next = new ListNode<int>(7)
        {
            Next = new ListNode<int>(7)
        }
    }
};
Console.WriteLine(JsonSerializer.Serialize(AddTwoNumbers(l1, l2)));
Console.ReadKey();

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

