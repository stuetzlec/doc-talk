namespace PipelineCore
{
    /// <summary>
    /// Represents a feedback collector that uses an evaluation strategy to evaluate responses.
    /// </summary>
    public class FeedbackCollector
    {
        private EvaluationStrategy evaluator;

        /// <summary>
        /// Initializes a new instance of the <see cref="FeedbackCollector"/> class.
        /// </summary>
        /// <param name="evaluator">The evaluation strategy to be used by the feedback collector.</param>
        public FeedbackCollector(EvaluationStrategy evaluator)
        {
            this.evaluator = evaluator;
        }

        /// <summary>
        /// Evaluates a response using the evaluation strategy.
        /// </summary>
        /// <param name="response">The response message to be evaluated.</param>
        public void EvaluateResponse(ResponseMessage response)
        {
            evaluator.EvaluateResponse(response);
        }

        /// <summary>
        /// Retrieves the evaluation result from the evaluation strategy.
        /// </summary>
        /// <returns>The evaluation result.</returns>
        public T GetEvaluation()
        {
            return evaluator.GetEvaluation();
        }
    }
}

