
using System.Text.Json;

ListNode<int> AddTwoNumbers(ListNode<int> firstList, ListNode<int> secondList)
{
    ListNode<int> head = new();
    ListNode<int> current = head;
    int carry = 0;
    while (firstList is { } || secondList is { })
    {
        int currentValFirst = firstList is {} ? firstList.Val : 0;
        int currentValSecond = secondList is {} ? secondList.Val : 0;
        int digit = carry + currentValFirst + currentValSecond;
        carry = digit / 10;
        current.Next = new ListNode<int>(digit % 10);
        current = current.Next;
        if (firstList is {}) 
        { 
            firstList = firstList.Next; 
        }
        if (secondList is {}) 
        { 
            secondList = secondList.Next; 
        }
    }
    if (carry > 0) 
    { 
        current.Next = new ListNode<int>(carry); 
    }
    return head.Next;
}

var l1 = new ListNode<int>(7);
l1.Next = new ListNode<int>(9);
l1.Next.Next = new ListNode<int>(3);

var l2 = new ListNode<int>(5);
l2.Next = new ListNode<int>(5);
l2.Next.Next = new ListNode<int>(7);
l2.Next.Next.Next = new ListNode<int>(7);
Console.WriteLine(JsonSerializer.Serialize(AddTwoNumbers(l1, l2)));
Console.ReadKey();

class ListNode<T>
{
    public T Val { get; set; }
    public ListNode<T> Next { get; set; }

    public ListNode(T val = default, ListNode<T> next = null)
    {
        Val = val;
        Next = next;
    }
}

