using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

public class PhraseNode
{
    public string Phrase { get; set; }
    public string LastSentence { get; set; }
    public int Count { get; set; }

    public PhraseNode(string phrase, string lastSentence)
    {
        Phrase = phrase;
        LastSentence = lastSentence;
        Count = 1;
    }

    public void Increment(string lastSentence)
    {
        LastSentence = lastSentence;
        Count++;
    }
}

public class FeedbackAlgorithm
{
    private Dictionary<string, PhraseNode> AvoidCount { get; set; }
    private Dictionary<string, PhraseNode> UseCount { get; set; }
    private string[] PhrasesToUse { get; set; }
    private string[] PhrasesToAvoid { get; set; }

    public FeedbackAlgorithm(string[] phrasesToUse, string[] phrasesToAvoid)
    {
        UseCount = new Dictionary<string, PhraseNode>();
        AvoidCount = new Dictionary<string, PhraseNode>();
        PhrasesToUse = phrasesToUse;
        PhrasesToAvoid = phrasesToAvoid;
    }

    public void Parse(string transcript)
    {
        // Check for "use" phrases and update the dictionary
        foreach (var phrase in PhrasesToUse)
        {
            var regex = new Regex(phrase, RegexOptions.IgnoreCase);
            var matches = regex.Matches(transcript);

            foreach (Match match in matches)
            {
                if (UseCount.ContainsKey(phrase))
                {
                    UseCount[phrase].Increment(transcript);
                }
                else
                {
                    UseCount[phrase] = new PhraseNode(phrase, transcript);
                }
            }
        }

        // Check for "avoid" phrases and update the dictionary
        foreach (var phrase in PhrasesToAvoid)
        {
            var regex = new Regex(phrase, RegexOptions.IgnoreCase);
            var matches = regex.Matches(transcript);

            foreach (Match match in matches)
            {
                if (AvoidCount.ContainsKey(phrase))
                {
                    AvoidCount[phrase].Increment(transcript);
                }
                else
                {
                    AvoidCount[phrase] = new PhraseNode(phrase, transcript);
                }
            }
        }
    }


    public void DisplayCounts()
    {
        Console.WriteLine("Phrases to Use:");
        foreach (var kvp in UseCount)
        {
            Console.WriteLine($"Phrase: '{kvp.Value.Phrase}', Count: {kvp.Value.Count}, Last Used In: {kvp.Value.LastSentence}");
        }

        Console.WriteLine("\nPhrases to Avoid:");
        foreach (var kvp in AvoidCount)
        {
            Console.WriteLine($"Phrase: '{kvp.Value.Phrase}', Count: {kvp.Value.Count}, Last Used In: {kvp.Value.LastSentence}");
        }
    }
}
