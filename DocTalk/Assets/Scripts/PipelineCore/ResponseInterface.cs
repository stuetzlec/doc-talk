
namespace PipelineCore
{
    public interface ResponseMessage<T>
    {
        ResponseMessage buildResponse();

        T GetValue();
    }
}