int Reverse(int x)
{
    var result = 0;

    const int positiveOverflow = int.MaxValue / 10;
    const int negativeOverflow = int.MinValue / 10;

    for (; x != 0; x /= 10)
    {
        if (result is > positiveOverflow or < negativeOverflow)
        {
            return 0;
        }
        result = result * 10 + x % 10;
    }

    return result;
}