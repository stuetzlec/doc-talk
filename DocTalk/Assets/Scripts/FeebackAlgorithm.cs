using System.Collections.Generic

public class PhraseNode
{
    private string Phrase { get; set; } // Phrase to search for
    private string LastSentence { get; set; } // Last seen usage of the phrase

    private int Count { get; } // Occurances

    public PhraseNode(string phrase, string lastSentence)
    {
        Phrase = phrase;
        LastSentence = lastSentence;
        Count = 1;
    }

    public void increment(string lastSentence)
    {
        LastSentence = lastSentence;
        Count = Count + 1
    }
}

public class FeedbackAlgorithm
{

    private PriorityQueue<PhraseNode, int> PhrasesToAvoidQ; // Queue representing the most commonly seen bad phrases
    private PriorityQueue<PhraseNode, int> PhrasesToUseQ; // Queue representing the most commonly seen good phrases
    private Dictionary<string, PhraseNode> PhrasesToAvoidDict; // Dictionary holding references to elements in the avoid Q
    private Dictionary<string, PhraseNode> PhrasesToUseDict;  // Dictionary holding references to elements in the use Q
    private string[] PhrasesToUse; // Good phrases to detect
    private string[] PhrasesToAvoid; // Bad phases to detect

    public FeedbackAlgorithm(string[] phrasesToUse, string[] phrasesToAvoid)
    {
        PhrasesToAvoidQ = new PriorityQueue<PhraseNode, int>();
        PhrasesToUseQ = new PriorityQueue<PhraseNode, int>();

        PhrasesToAvoidDict = new Dictionary<string, PhraseNode>();
        PhrasesToUseDict = new Dictionary<string, PhraseNode>();

        PhrasesToAvoid = Phrases.PhrasesToAvoid;
        PhrasesToUse = Phrases.PhrasesToUse;
    }

    private void EnqueueOrUpdate(PriorityQueue<PhraseNode, int> queue, Dictionary<string, PhraseNode> dict, string phrase, string lastSentence)
    {

        if (dict.TryGetValue(phrase, out var existingElement))
        {
            // If the element exists, update its count and reinsert it into the queue
            priorityQueue.Enqueue(existingElement, int.MaxValue); // Invalidate existing priority by adding a high value
            existingElement.Count += count;
        }
        else
        {
            // If the element doesn't exist, create a new one and add it to the dictionary
            existingElement = new Element(phrase, count);
            dict[phrase] = existingElement;
        }

        // Reinsert with updated count as priority
        priorityQueue.Enqueue(existingElement, existingElement.Count);
    }

    public void parse(string transcript) 
    {

    }

}
