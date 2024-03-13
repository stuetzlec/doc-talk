using System;

namespace PipelineCore
{
    public class FeedbackCollector
    {
        private EvaluationStrategy evaluator;

        public FeedbackCollector(EvaluationStrategy evaluator)
        {
            this.evaluator = evaluator;
        }

        public void EvaluateResponse(ResponseMessage response)
        {
            evaluator.EvaluateResponse(ResponseMessage response);
        }

        public T getEvaluation() {
           return evaluator.getEvaluation();
        }
    }
}
