public int countMeetings(int[] firstDay, int[] lastDay)
{
    if (firstDay == null || lastDay == null || firstDay.Length != lastDay.Length)
        return 0;
        
    int n = firstDay.Length;
    var investors = new List<(int start, int end)>();
    for (int i = 0; i < n; i++)
        investors.Add((firstDay[i], lastDay[i]));

    // Sort by lastDay (end)
    investors.Sort((a, b) => a.end.CompareTo(b.end));

    var usedDays = new HashSet<int>();
    int meetings = 0;

    foreach (var investor in investors)
    {
        // Try to schedule on the earliest available day in their range
        for (int day = investor.start; day <= investor.end; day++)
        {
            if (!usedDays.Contains(day))
            {
                usedDays.Add(day);
                meetings++;
                break;
            }
        }
    }

    return meetings;
}
