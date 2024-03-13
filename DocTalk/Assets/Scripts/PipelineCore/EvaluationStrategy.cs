namespace PipelineCore
{
    interface EvaluationStrategy<T>
    {
        void EvaluateResponse(ResponseMessage responseMessage);

        T getEvaluation();

    }
}