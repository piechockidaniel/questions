public int[] substitutions(string[] words, string[] phrases)
{
    if (words == null || phrases == null)
        return new int[0];

    // Group anagrams
    var anagramGroups = new Dictionary<string, List<string>>();
    
    foreach (var word in words)
    {
        string key = new string(word.OrderBy(c => c).ToArray());
        
        if (!anagramGroups.ContainsKey(key))
            anagramGroups[key] = new List<string>();
            
        anagramGroups[key].Add(word);
    }
    
    // Process each phrase
    int[] result = new int[phrases.Length];
    
    for (int i = 0; i < phrases.Length; i++)
    {
        string[] phraseWords = phrases[i].Split(' ');
        int totalPhrases = 1;
        
        foreach (var word in phraseWords)
        {
            string key = new string(word.OrderBy(c => c).ToArray());
            if (anagramGroups.ContainsKey(key))
                totalPhrases *= anagramGroups[key].Count;
        }
        
        result[i] = totalPhrases;
    }
    
    return result;
}
