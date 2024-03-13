namespace PipelineCore
{
    
    public interface ConversationalModel
    {
        ResponseMessage CreateResponse(ResponseMessage response);
    }
}