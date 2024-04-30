// ApologyPhrases.cs contains keywords and phrases to be tallied by the feedback collector.

public static class Phrases
{
    // Words and phrases to avoid in apologies
    public static readonly string[] PhrasesToAvoid = new string[]
    {
        "but",
        "however",
        "if",
        "might",
        "maybe",
        "perhaps",
        "sorry if",
        "I'm sorry but",
        "I'm sorry you feel",
        "I'm sorry you think",
        "I'm sorry that you",
        "we apologize if",
        "it was not my intention",
        "it's not my fault",
        "you should have",
        "you misunderstood",
        "it's not our responsibility",
        "not what I meant",
        "misunderstanding",
        "don't take it personally",
        "calm down",
        "let's move on",
        "joking",
        "no offense",
        "didn't mean it",
        "isn't a big deal",
        "overreacting",
        "your fault",
        "this is how things are",
        "everyone makes mistakes"
    };

    // Contrapositive phrases for constructive apologies
    public static readonly string[] PhrasesToUse = new string[]
    {
        "and",
        "I understand",
        "regardless of",
        "definitely",
        "I'm certain",
        "this is clear",
        "I'm sorry that",
        "I'm sorry for",
        "I'm sorry about",
        "we apologize for",
        "taking responsibility",
        "it's our responsibility",
        "correct my words",
        "requires immediate attention",
        "your feelings are valid",
        "I understand your frustration",
        "let's address this",
        "I take responsibility",
        "I need to make amends",
        "I'm listening to you",
        "your feedback is important",
        "thank you for bringing this up",
        "I recognize my mistake",
        "how can we improve",
        "I appreciate your patience",
        "I take this seriously",
        "how can I make this right",
        "I value our relationship",
        "we're in this together",
        "everyone deserves respect"
    };
}
