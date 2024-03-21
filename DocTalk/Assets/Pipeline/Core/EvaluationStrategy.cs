namespace PipelineCore
{
    /// <summary>
    /// Represents a strategy for evaluating responses in a pipeline.
    /// </summary>
    /// <typeparam name="T">The type of evaluation result.</typeparam>
    public interface EvaluationStrategy<T>
    {
        /// <summary>
        /// Evaluates a response message.
        /// </summary>
        /// <param name="responseMessage">The response message to be evaluated.</param>
        void EvaluateResponse(ResponseMessage responseMessage);

        /// <summary>
        /// Gets the evaluation result.
        /// </summary>
        /// <returns>The evaluation result of type <typeparamref name="T"/>.</returns>
        T GetEvaluation();
    }
}
